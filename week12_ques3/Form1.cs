using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace week12_ques3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            
            XmlDocument file = new XmlDocument();

            file.Load(@"C:\Users\yui10\Desktop\week12_csharp\Bookstore.xml");
            XmlNode book_node = file.SelectSingleNode("bookstore");
            XmlElement xe1 = file.CreateElement("book");
            xe1.SetAttribute("category", "children");

            XmlElement xesub1 = file.CreateElement("title");
            xesub1.InnerText = "Huluwa";//设置文本节点
            xe1.AppendChild(xesub1);//添加到<Node>节点中
            XmlElement xesub2 = file.CreateElement("author");
            xesub2.InnerText = "测试作者";
            xe1.AppendChild(xesub2);
            XmlElement xesub4 = file.CreateElement("year");
            xesub4.InnerText = "2001";
            xe1.AppendChild(xesub4);
            XmlElement xesub3 = file.CreateElement("price");
            xesub3.InnerText = "价格";
            xe1.AppendChild(xesub3);
            book_node.AppendChild(xe1);



            XmlNodeList someBooks = book_node.SelectNodes("/bookstore/book[price<30]");
            for (int i = 0; i < someBooks.Count; i++)
            {
                someBooks.Item(i).ParentNode.RemoveChild(someBooks.Item(i));
            }
            Console.WriteLine(file.OuterXml);
            file.Save("demo3.xml");



        }
    }
}

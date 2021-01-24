    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.XPath;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XPathNavigator nav;
                XPathDocument docNav;
                string xPath;
                docNav = new XPathDocument(AppDomain.CurrentDomain.BaseDirectory + "test.xml");
                nav = docNav.CreateNavigator();
                xPath = "/Header/CollectionDetails/Year/text()";
                string value = nav.SelectSingleNode(xPath).Value;
                Console.WriteLine(value);
            }
        }
    }

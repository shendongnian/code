    using System;
    using System.Xml.XPath;
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument xpdoc = new XPathDocument(@"sample.xml");
            XPathNavigator nav = xpdoc.CreateNavigator();
            XPathNodeIterator iter = nav.Select("//*[text() = 'Företag']");
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current.ToString());
            }
        }
    }

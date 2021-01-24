    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME1 = @"c:\temp\test.xml";
            const string FILENAME2 = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME1);
                Dictionary<string, string> dict = doc.Descendants("Columns").FirstOrDefault().Elements()
                    .GroupBy(x => (string)x.Attribute("XPath"), y => (string)y.Attribute("Name"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                XDocument order = XDocument.Load(FILENAME2);
                List<XElement> positions = order.Descendants("Position").ToList();
                foreach (XElement position in positions)
                {
                    foreach (XAttribute attribute in position.Attributes())
                    {
                        string name = attribute.Name.LocalName;
                        string value = (string)attribute;
                        if(dict.ContainsKey("@" + name))
                        {
                           string xName = dict["@" + name];
                           Console.WriteLine("Key = '{0}', Name = '{1}'", name, xName);
                        }
                        else
                        {
                            Console.WriteLine("Not in dictionary : Key = '{0}'", name);
                        }
                    }
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement add in doc.Descendants("add"))
                {
                    string[] values = add.Attribute("value").Value.Split(new char[] {'.'});
                    values[values.Length - 1] = (int.Parse(values[values.Length - 1]) + 1).ToString();
                    add.SetAttributeValue("value", string.Join(".", values));
                }
     
            }
        }
     
     
    }

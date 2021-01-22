    using System;
    using System.Xml.Linq;
    using System.Xml.XPath; // for XPathSelectElements
    
    namespace testconsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument xdoc = XDocument.Parse(
                    @"<root>
                        <child>
                            <name>john</name>
                        </child>
                        <child>
                            <name>fred</name>
                        </child>
                        <child>
                            <name>mark</name>
                        </child>
                     </root>");
    
                foreach (var childElem in xdoc.XPathSelectElements("//child"))
                {
                    string childName = childElem.Element("name").Value;
                    Console.WriteLine(childName);
                }
            }
        }
    }

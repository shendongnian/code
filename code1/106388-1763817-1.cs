    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Linq;
    namespace TestIdeas
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement i1 = XElement.Parse(@" <item>
                                                    <title>A test</title>
                                                    <titlelong>A</titlelong>
                                                    <type>test</type>
                                                    <description>
                                                        Some description
                                                    </description>
                                                    <image>includes/images/test.jpg</image>
                                                    <imagelink>http://somesite.com</imagelink>
                                                </item>");
                XElement i2 = XElement.Parse(@" <item>
                                                    <title>E test2</title>
                                                    <titlelong>E</titlelong>
                                                    <type>test</type>
                                                    <description>
                                                        Another sample
                                                    </description>
                                                    <image>includes/images/test.jpg</image>
                                                    <imagelink>http://somesite.com</imagelink>
                                                </item>");
                XElement root = new XElement("root");
                root.Add(new[] { i1, i2 });
                var ts = from t in root.Elements("item").Elements("title")
                          where t.Value[0] >= 'A' && t.Value[0] <= 'E'
                          select t;
                foreach (XElement t in ts)
                {
                    Console.WriteLine(t.Value);
                }
                Console.ReadLine();
            }
        }
    }

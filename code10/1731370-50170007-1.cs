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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                var reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "EventData")
                    {
                        reader.ReadToFollowing("EventData");
                    }
                    if (!reader.EOF)
                    {
                        XElement eventData = (XElement)XElement.ReadFrom(reader);
                        foreach (XElement data in eventData.Elements("Data"))
                        {
                            Console.WriteLine("{0} : {1}", (string)data.Attribute("Name"), (string)data);
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }

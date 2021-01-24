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
                    reader.MoveToContent();
                    string ns = reader.NamespaceURI;
                    //if this doesn't work hard code ns
                    // string ns = "http://www.netapp.com/schemas/ONTAP/2007/AuditLog";
                    while (!reader.EOF)
                    {
                        if (reader.Name != "EventData")
                        {
                            reader.ReadToFollowing("EventData",ns);
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

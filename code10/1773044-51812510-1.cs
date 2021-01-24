    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                 using (var fs = new MemoryStream(UTF8Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""utf-8""?><test><node id=""123"">
                                <tag k=""amenity"" v=""fuel"" />
                            </node><node id=""456"">
                                <tag k=""name"" v=""B"" />
                            </node><node id=""789"">
                                <tag k=""amenity"" v=""test"" />
                            </node></test>")))
                {
                    XmlReader reader = XmlReader.Create(fs);
                    while (!reader.EOF)
                    {
                        if(reader.Name != "node")
                        {
                            reader.ReadToFollowing("node");
                        }
                        if(!reader.EOF)
                        {
                            XElement node = (XElement)XElement.ReadFrom(reader);
                            int id = (int)node.Attribute("id");
                            Console.WriteLine(id.ToString());
                        }
                    }
                }
                Console.ReadLine();
      
            }
        }
    }

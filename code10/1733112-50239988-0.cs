    <test>
       <Section>
           <book Name="Titan Quest 1"/>
           <book Name="Titan Quest 2"/>
           <book Name="Adventure Willy"/>
           <book Name="Mr. G and the Sandman"/>
           <book Name="Terry and Me"/>
       </Section>
       <Section>
           <cd Name="Titan Quest 1"/>
           <book Name="Titan Quest 2"/>
           <vhs Name="Adventure Willy"/>
           <cd Name="Mr. G and the Sandman"/>
           <dvd Name="Terry and Me"/>
       </Section>
    </test>
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
                List<List<KeyValuePair<string, string>>> books = new List<List<KeyValuePair<string, string>>>();
                using (XmlReader reader = XmlReader.Create(FILENAME))
                {
                    while (!reader.EOF)
                    {
                        if (reader.Name != "Section")
                        {
                            reader.ReadToFollowing("Section");
                        }
                        if (!reader.EOF)
                        {
                            XElement section = (XElement)XElement.ReadFrom(reader);
                            List<KeyValuePair<string, string>> book = new List<KeyValuePair<string, string>>();
                            books.Add(book);
                            foreach (XElement b in section.Elements())
                            {
                                book.Add(new KeyValuePair<string, string>(b.Name.LocalName, (string)b.Attribute("Name")));
                            }
                        }
                    }
                }
            }
        }
    }

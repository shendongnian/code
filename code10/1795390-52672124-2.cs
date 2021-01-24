    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
     
                Element newElement = new Element() {
                    Name = "John",
                    Picture = "Dorian Grey",
                    Data1 = "1",
                    Data2 = "1",
                    Data3 = "1",
                    Data4 = "1",
                    Data5 = "1",
                    Data6 = "1",
                    Data7 = "1",
                    Data8 = "1",
                    Data9 = "1",
                    Data10 = "1",
                    Data11 = "1",
                    Data12 = "1",
                    Data13 = "1",
                    Data14 = "1",
                    Data15 = "1",
                    Data16 = "1",
                    Data17 = "1",
                    Data18 = "1",
                    Data19 = "1",
                    Data20 = "1",
                    Data21 = "1",
                    Data22 = "1",
                    Data23 = "1",
                    Data24 = "1",
                    Data25 = "1",
                    Data26 = "1",
                    Data27 = "1",
                    Data28 = "1",
                    Data29 = "1",
                    Data30 = "1"
                };
                Root root = new Root();
                for (int i = 0; i < 29; i++)
                {
                    root.elements.Add(newElement);
                }
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, setting);
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                serializer.Serialize(writer, root);
                writer.Flush();
                writer.Close();
                XDocument doc = XDocument.Load(FILENAME);
                DateTime start1 = DateTime.Now;
                List<Element> units = new List<Element>();
                List<XElement> elements = doc.Root.Elements().ToList();
                foreach (var c in elements)
                {
                    Element stb = new Element();
                    stb.Name = c.Element("Name").Value;
                    stb.Picture = c.Element("Picture").Value;
                    stb.Data1 = c.Element("Data1").Value;
                    stb.Data2 = c.Element("Data2").Value;
                    stb.Data3 = c.Element("Data3").Value;
                    stb.Data4 = c.Element("Data4").Value;
                    stb.Data5 = c.Element("Data5").Value;
                    stb.Data6 = c.Element("Data6").Value;
                    stb.Data7 = c.Element("Data7").Value;
                    stb.Data8 = c.Element("Data8").Value;
                    stb.Data9 = c.Element("Data9").Value;
                    stb.Data10 = c.Element("Data10").Value;
                    stb.Data11 = c.Element("Data11").Value;
                    stb.Data12 = c.Element("Data12").Value;
                    stb.Data13 = c.Element("Data13").Value;
                    stb.Data14 = c.Element("Data14").Value;
                    stb.Data15 = c.Element("Data15").Value;
                    stb.Data16 = c.Element("Data16").Value;
                    stb.Data17 = c.Element("Data17").Value;
                    stb.Data18 = c.Element("Data18").Value;
                    stb.Data19 = c.Element("Data19").Value;
                    stb.Data20 = c.Element("Data20").Value;
                    stb.Data21 = c.Element("Data21").Value;
                    stb.Data22 = c.Element("Data22").Value;
                    stb.Data23 = c.Element("Data23").Value;
                    stb.Data24 = c.Element("Data24").Value;
                    stb.Data25 = c.Element("Data25").Value;
                    stb.Data26 = c.Element("Data26").Value;
                    stb.Data27 = c.Element("Data27").Value;
                    stb.Data28 = c.Element("Data28").Value;
                    stb.Data29 = c.Element("Data29").Value;
                    stb.Data30 = c.Element("Data30").Value;
                    units.Add(stb);
                }
                DateTime end1 = DateTime.Now;
                DateTime start2 = DateTime.Now;
                List<Element> elements2 = doc.Descendants("elements").Select(x => new Element()
                {
                    Name = (string)x.Element("Name"),
                    Picture = (string)x.Element("Picture"),
                    Data1 = x.Element("Data1").Value,
                    Data2 = x.Element("Data2").Value,
                    Data3 = x.Element("Data3").Value,
                    Data4 = x.Element("Data4").Value,
                    Data5 = x.Element("Data5").Value,
                    Data6 = x.Element("Data6").Value,
                    Data7 = x.Element("Data7").Value,
                    Data8 = x.Element("Data8").Value,
                    Data9 = x.Element("Data9").Value,
                    Data10 = x.Element("Data10").Value,
                    Data11 = x.Element("Data11").Value,
                    Data12 = x.Element("Data12").Value,
                    Data13 = x.Element("Data13").Value,
                    Data14 = x.Element("Data14").Value,
                    Data15 = x.Element("Data15").Value,
                    Data16 = x.Element("Data16").Value,
                    Data17 = x.Element("Data17").Value,
                    Data18 = x.Element("Data18").Value,
                    Data19 = x.Element("Data19").Value,
                    Data20 = x.Element("Data20").Value,
                    Data21 = x.Element("Data21").Value,
                    Data22 = x.Element("Data22").Value,
                    Data23 = x.Element("Data23").Value,
                    Data24 = x.Element("Data24").Value,
                    Data25 = x.Element("Data25").Value,
                    Data26 = x.Element("Data26").Value,
                    Data27 = x.Element("Data27").Value,
                    Data28 = x.Element("Data28").Value,
                    Data29 = x.Element("Data29").Value,
                    Data30 = x.Element("Data30").Value,
                }).ToList();
                DateTime end2 = DateTime.Now;
                string results = string.Format("Time 1 = '{0}', Time 2 = '{1}'", (end1 - start1).TotalMilliseconds, (end2 - start2).TotalMilliseconds); 
                Console.ReadLine();
            }
        }
        public class Root
        {
            [XmlElement]
            public List<Element> elements = new List<Element>();
        }
        public class Element
        {
            public string Name { get; set; }
            public string Picture { get; set; }
            public string Data1 { get; set; }
            public string Data2 { get; set; }
            public string Data3 { get; set; }
            public string Data4 { get; set; }
            public string Data5 { get; set; }
            public string Data6 { get; set; }
            public string Data7 { get; set; }
            public string Data8 { get; set; }
            public string Data9 { get; set; }
            public string Data10 { get; set; }
            public string Data11 { get; set; }
            public string Data12 { get; set; }
            public string Data13 { get; set; }
            public string Data14 { get; set; }
            public string Data15 { get; set; }
            public string Data16 { get; set; }
            public string Data17 { get; set; }
            public string Data18 { get; set; }
            public string Data19 { get; set; }
            public string Data20 { get; set; }
            public string Data21 { get; set; }
            public string Data22 { get; set; }
            public string Data23 { get; set; }
            public string Data24 { get; set; }
            public string Data25 { get; set; }
            public string Data26 { get; set; }
            public string Data27 { get; set; }
            public string Data28 { get; set; }
            public string Data29 { get; set; }
            public string Data30 { get; set; }
        }
    }

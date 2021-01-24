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
                XDocument doc = XDocument.Load(FILENAME);
                Root root = doc.Elements("root").Select(x => new Root() {
                    largeImages = x.Descendants("largeImage").Select(z => new Image()
                    {
                        url = (string)z.Element("url"),
                        height = (int)z.Element("height"),
                        width = (int)z.Element("width")
                    }).ToArray(),
                    smallImages = x.Descendants("largeImage").Select(z => new Image()
                    {
                        url = (string)z.Element("url"),
                        height = (int)z.Element("height"),
                        width = (int)z.Element("width")
                    }).ToArray()
                }).FirstOrDefault();
            }
        }
        public class Root
        {
            public Image[] largeImages { get; set; }
            public Image[] smallImages { get; set; }
        }
        public class Image
        {
            public string url { get; set; }
            public int height { get; set; }
            public int width { get; set; }
        }
    }

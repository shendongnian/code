    using System;
    using System.Collections.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Drawing;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, Dictionary<string, PaletteColor>> dict = doc.Descendants("PALETTE")
                    .GroupBy(x => (string)x.Attribute("id"), y => y.Elements("COLOR").Select(c => new PaletteColor() { name = (string)c.Element("Name"), color = Color.FromArgb(int.Parse(((string)c.Element("RGBString")).Substring(1), System.Globalization.NumberStyles.HexNumber)) })
                        .GroupBy(a => a.name, b => b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class PaletteColor
        {
            public string name { get; set; }
            public Color color { get; set; }
        }
    }

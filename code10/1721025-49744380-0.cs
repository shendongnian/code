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
                Dictionary<string, Dictionary<string, Color>> dict = doc.Descendants("PALETTE")
                    .GroupBy(x => (string)x.Attribute("id"), y => y.Elements("COLOR")
                        .GroupBy(a => (string)a.Element("Name"), b => Color.FromArgb(int.Parse(((string)b.Element("RGBString")).Substring(1),System.Globalization.NumberStyles.HexNumber)))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }

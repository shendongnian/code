    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication52
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<urun> uruns = doc.Descendants("urun").Select(x => new urun() {
                    resimDosyasi = (string)x.Element("resimDosyasi"),
                    aciklama = (string)x.Element("aciklama"),
                    birim = (string)x.Element("birim"),
                    miktar = (int)x.Element("miktar"),
                    toplam = (string)x.Element("toplam")
                }).ToList();
            }
        }
        public class urun
        {
            public string resimDosyasi { get; set; }
            public string aciklama { get; set; }
            public string birim { get; set; }
            public int miktar { get; set; }
            public string toplam { get; set; }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Panel(FILENAME);
            }
        }
        public class Panel
        {
            public static Dictionary<string, Panel> panels = new Dictionary<string, Panel>();
            public string Type { get; set; }
            public string PbtId { get; set; }
            public string PrtId { get; set; }
            public Panel() { }
            public Panel(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                panels = doc.Descendants("panel").Select(x => new Panel()
                {
                    Type = (string)x.Element("type"),
                    PbtId = (string)x.Element("pbt_id")
                }).GroupBy(x => x.PbtId, y => y)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (XElement  pbt in doc.Descendants("pbt"))
                {
                    string id = (string)pbt.Element("id");
                    string prt_id = (string)pbt.Element("prt_id");
                    if(panels.ContainsKey(id))
                    {
                        panels[id].PrtId = prt_id;
                    }
                }
            }
        }
    }

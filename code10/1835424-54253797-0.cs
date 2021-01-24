    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication97
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Respcondition> responses = doc.Descendants("respcondition").Select(x => new Respcondition()
                {
                    _continue = (string)x.Attribute("continue"),
                    varequal = (string)x.Descendants("varequal").FirstOrDefault(),
                    respident = (string)x.Descendants("varequal").FirstOrDefault().Attribute("respident"),
                    setvar = (string)x.Element("setvar"),
                    action = (string)x.Element("setvar").Attribute("action"),
                    linkrefid = (string)x.Element("displayfeedback").Attribute("linkrefid"),
                    feedbacktype = (string)x.Element("displayfeedback").Attribute("feedbacktype")
                }).ToList();
                Dictionary<string, List<Respcondition>> dict = responses.GroupBy(x => x.respident, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
     
            }
        }
        public class Respcondition
        {
            public string _continue { get; set; }
            public string varequal { get; set; }
            public string respident { get; set; }
            public string setvar { get; set; }
            public string action { get; set; }
            public string linkrefid { get; set; }
            public string feedbacktype { get; set; }
        }
    }
     //<respcondition continue="Yes">
     //   <conditionvar>
     //     <varequal respident="gap_0">auswahl1</varequal>
     //   </conditionvar>
     //   <setvar action="Add">1</setvar>
     //   <displayfeedback linkrefid="0_Response_0" feedbacktype="Response"/>
     // </respcondition>

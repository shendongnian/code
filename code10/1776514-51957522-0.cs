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
            const string FILENAME1 = @"c:\temp\test1.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument xTools = XDocument.Load(FILENAME2);
                Dictionary<int, Tool> toolsDict = xTools.Descendants("tool")
                    .Select(x => new Tool() {
                        id = (int)x.Attribute("id"),
                        name = (string)x.Element("toolName"),
                        pn = (string)x.Element("toolPN"),
                        cage = (string)x.Element("toolCage")
                    }).GroupBy(x => x.id, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                XDocument xTasks = XDocument.Load(FILENAME1);
                List<XElement> toolTask = xTasks.Descendants("tool").ToList();
                foreach (XElement tool in toolTask)
                {
                    int id = (int)tool.Element("id");
                    int qty = (int)tool.Element("qty");
                    if(toolsDict.ContainsKey(id))
                    {
                        Tool idTool = toolsDict[id];
                        tool.ReplaceWith(new XElement("tool", new object[] {
                            new XAttribute("id", id),
                            new XAttribute("qty", qty),
                            new XElement("toolName", idTool.name),
                            new XElement("toolPN", idTool.pn),
                            new XElement("toolCage", idTool.cage)
                        }));
                    }
              //                 <toolName>Hammer</toolName>
              //  <toolPN>345123</toolPN>
              //  <toolCage>-</toolCage>
              //</tool>
                }
            }
        }
        public class Tool
        {
            public int id { get;set;}
            public string name { get; set; }
            public string pn { get; set; }
            public string cage { get; set; }
        }
    }

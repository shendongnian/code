    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Events(FILENAME);
            }
        }
        public class Events
        {
            public static DataTable dt = new DataTable();
            public static int idCount = 0;
            public Events() { }
            public Events(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement eventList = doc.Descendants("eventList").FirstOrDefault();
                string[] columnNames = eventList.Descendants().Select(x => (string)x.Name.LocalName).Distinct().OrderBy(x => x).ToArray();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Parent ID", typeof(int));
                foreach (string columName in columnNames)
                {
                    dt.Columns.Add(columName, typeof(string));
                }
                int rootId = idCount;
                RecursiveParse(eventList, rootId);
            }
            public void RecursiveParse(XElement parent, int parentID)
            {
                foreach(XElement child in parent.Elements())
                {
                    int childId = idCount++;
                    DataRow row = dt.Rows.Add();
                    row["Parent ID"] = parentID;
                    row["ID"] = childId;
                    string name = child.Name.LocalName;
                    string value = (string)child;
                    row[name] = value;
                    if (child.HasElements)
                    {
                        RecursiveParse(child, childId);
                    }
                }
            }
        }
    }

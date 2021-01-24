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
            const string MASTER_FILENAME = @"c:\temp\test.xml";
            const string CHILD_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument master = XDocument.Load(MASTER_FILENAME);
                XElement masterSysConfig = master.Descendants("SysConfig").FirstOrDefault();
                masterSysConfig.Nodes().Remove();
                XDocument child = XDocument.Load(CHILD_FILENAME);
                masterSysConfig.Add(child.Nodes().Cast<XElement>());
            }
        }
    }

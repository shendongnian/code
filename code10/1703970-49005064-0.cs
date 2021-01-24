    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string input = "";
                string xml = "";
                while((input = reader.ReadLine()) != null)
                {
                    if (!input.StartsWith("<?xml"))
                    {
                        xml += input;
                    }
                }
                StringReader sReader = new StringReader(xml);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader xReader = XmlReader.Create(sReader, settings);
                List<XElement> reports = new List<XElement>();
                while (!xReader.EOF)
                {
                    if (xReader.Name != "Report")
                    {
                        xReader.ReadToFollowing("Report");
                    }
                    if (!xReader.EOF)
                    {
                        reports.Add((XElement)XElement.ReadFrom(xReader));
                    }
                }
                 
            }
        }
    }

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
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "TestResult")
                    {
                        reader.ReadToFollowing("TestResult");
                    }
                    if (!reader.EOF)
                    {
                        XElement testResult = (XElement)XElement.ReadFrom(reader);
                        string image = (string)testResult.Element("TestResultImage"); 
                    }
                }
            }
        }
    }

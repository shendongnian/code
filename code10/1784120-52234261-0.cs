    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication63
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "managedObject")
                    {
                        reader.ReadToFollowing("managedObject");
                    }
                    if (!reader.EOF)
                    {
                        XElement managedObject = (XElement) XElement.ReadFrom(reader);
                        string mClass = (string)managedObject.Attribute("class");
                        string distName = (string)managedObject.Attribute("distName");
                        Dictionary<string, string> dict = managedObject.Elements()
                            .GroupBy(x => (string)x.Attribute("name"), y => (string)y)
                            .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    }
                }
            }
        }
    }

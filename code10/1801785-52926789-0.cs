    using System;
    using System.Collections.Generic;
    using System.Collections;
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
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> lengthElements = doc.Descendants("StreamsetInfo").Where(x => x.Attribute("Length") != null).ToList();
                var results = lengthElements.Select(x => new {
                    streamId = (string)x.Attribute("StreamId"),
                    abcName = (string)x.Attribute("abcName"),
                    vcName = (string)x.Attribute("VcName"),
                    length = (long)x.Attribute("Length"),
                    count = (int)x.Attribute("Count"),
                    creationTime = (DateTime)x.Attribute("CreationTime"),
                    expirationTime = (DateTime)x.Attribute("ExpirationTime"),
                    modificationTime = (DateTime)x.Attribute("ModificationTime")
                }).ToList();
            }
        }
    }
 

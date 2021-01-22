       public class Project
        {
            public string Name { get; set; }
            public List<Message> MessageCollection = new List<Message>();
    
            public void LoadFromXml(string xmlString)
            {
                // From System.Xml.Linq
                XDocument xDocument = XDocument.Parse(xmlString);
    
                // The following assumes your XML is well formed, is not missing attributes and has no type conversion problems. In
                // other words, there is (almost) zero error checking.
                if (xDocument.Document != null)
                {
                    XElement projectElement = xDocument.Element("Project");
    
                    if (projectElement != null)
                    {
                        Name = projectElement.Attribute("Name") == null ? "Untitled Project" : projectElement.Attribute("Name").Value;
    
                        MessageCollection = new List<Message>
                            (from message in xDocument.Element("Project").Elements("Messages")
                             select new Message()
                                    {
                                        Name = message.Attribute("Name").Value,
                                        BitfieldCollection = new List<BitField>
                                            (from bitField in message.Elements("Bitfields")
                                                select new BitField() {High = int.Parse(bitField.Attribute("High").Value), Low = int.Parse(bitField.Attribute("Low").Value)})
                                    }
                            );
                    }
                }
            }
        }
    
        public class Message
        {
            public string Name { get; set; }
            public List<BitField> BitfieldCollection = new List<BitField>();
        }
    
        public class BitField
        {
            public int High { get; set; }
            public int Low { get; set; }
            public List<string> ValueCollection = new List<string>();
        }

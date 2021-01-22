    using System.Collections.Generic;
    using System.Configuration;
    using System.Xml;
    namespace TestReadMultipler2343
    {
        public class BackupDirectoriesSection : IConfigurationSectionHandler
        {
            public object Create(object parent, object configContext, XmlNode section)
            {
                List<directory> myConfigObject = new List<directory>();
                foreach (XmlNode childNode in section.ChildNodes)
                {
                    foreach (XmlAttribute attrib in childNode.Attributes)
                    {
                        myConfigObject.Add(new directory() { location = attrib.Value });
                    }
                }
                return myConfigObject;
            }
        }
        public class directory
        {
            public string location { get; set; }
        }
    }

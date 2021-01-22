    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace Foo
    {    
        [XmlRoot(ElementName = "Config")]
        public class Config
        {        
            public String GuiPath { get; set; }
    
            public Boolean Save(String path)
            {
                var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                try
                {
                    var serializer = new XmlSerializer(typeof(Config));
                    serializer.Serialize(fileStream, this);
                    return true;
                }
                catch { return false; }
                finally { fileStream.Close(); }
            }
    
            public static Config Load(String path)
            {
                var fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
                try
                {
                    var serializer = new XmlSerializer(typeof(Config));
                    return (Config)serializer.Deserialize(fileStream);
                }
                finally { fileStream.Close(); }
            }
        }
    }

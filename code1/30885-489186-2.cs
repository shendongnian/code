    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    
    namespace Foo
    {    
        [XmlRoot(ElementName = "Config")]
        public class Config
        {        
            public String GuiPath { get; set; }
    
            public Boolean Save(String path)
            {
                using (var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(Config));
                        serializer.Serialize(fileStream, this);
                        return true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        // Other exception handling here
                        return false;
                    }
                }
            }
    
            public static Config Load(String path)
            {
                using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(Config));
                        return (Config)serializer.Deserialize(fileStream);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        // Other exception handling here
                        return null;
                    }
                }
            }
        }
    }

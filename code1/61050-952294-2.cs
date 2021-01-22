     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;
    using System.Xml;
    
    namespace TestStuff
    {
        public class Configuration
        {
            #region properties
    
            public List<string> UIComponents { get; set; }
            public List<string> Settings { get; set; }
    
            #endregion
    
            //serialize itself
            public string Serialize()
            {
                MemoryStream memoryStream = new MemoryStream();
    
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                using (StreamWriter xmlTextWriter = new StreamWriter(memoryStream))
                {
                    xs.Serialize(xmlTextWriter, this);
                    xmlTextWriter.Flush();
                    //xmlTextWriter.Close();
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    StreamReader reader = new StreamReader(memoryStream);
    
                    return reader.ReadToEnd();
                }
            }
    
            //deserialize into itself
            public void Deserialize(string xmlString)
            {
                String XmlizedString = null;
    
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter w = new StreamWriter(memoryStream))
                    {
                        w.Write(xmlString);
                        w.Flush();
    
                        XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        XmlReader reader = XmlReader.Create(memoryStream);
    
                        Configuration currentConfig = (Configuration)xs.Deserialize(reader);
    
                        this.Settings = currentConfig.Settings;
                        this.UIComponents = currentConfig.UIComponents;
    
                        w.Close();
                    }
                }
            }
            static void Main(string[] args)
            {
                Configuration thisConfig = new Configuration();
                thisConfig.Settings = new List<string>(){
                    "config1", "config2"
                };
                thisConfig.UIComponents = new List<string>(){
                    "comp1", "comp2"
                };
                //serializing the object
                string serializedString = thisConfig.Serialize();
    
    
                Configuration myConfig = new Configuration();
                //deserialize into myConfig object
                myConfig.Deserialize(serializedString);
            }
        }
    
       
    }

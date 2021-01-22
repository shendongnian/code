    public class Configuration
        {
            #region properties
            
            public SerializableDictionary<string, RegisteredUIComponent> UIComponents { get; set; }
            public SerializableDictionary<string, string> Settings { get; set; }
    
            #endregion
    
            //serialize itself
            public  string Serialize()
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                StreamWriter xmlTextWriter = new StreamWriter(memoryStream);
    
                xs.Serialize(xmlTextWriter, this);
                xmlTextWriter.Flush();
                //xmlTextWriter.Close();
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                memoryStream.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(memoryStream);
    
                return reader.ReadToEnd();
            }
    
            //deserialize into itself
            public  void Deserialize(string xmlString)
            {
                String XmlizedString = null;
    
                MemoryStream memoryStream = new MemoryStream();
                StreamWriter w = new StreamWriter(memoryStream);
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

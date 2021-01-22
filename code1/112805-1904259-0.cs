    [Serializable]
    public class EncryptedValues
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public static EncryptedValues FromXml(string xmlString)
        {
            if (!string.IsNullOrEmpty(xmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(EncryptedValues));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter streamWriter = new StreamWriter(memoryStream))
                    {
                        streamWriter.Write(xmlString);
                        streamWriter.Flush();
                        memoryStream.Flush();
                        memoryStream.Position = 0;
                        return (xmlSerializer.Deserialize(memoryStream) as EncryptedValues);
                    }
                }
            }
            return null;
        }
        public string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(EncryptedValues));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(memoryStream))
                {
                    xmlSerializer.Serialize(streamWriter, o);
                    streamWriter.Flush();
                    memoryStream.Flush();
                    memoryStream.Position = 0;
                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

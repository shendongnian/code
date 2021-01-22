    [Serializable]
    public class MyData 
    {
        public int MyNumber { get; set; }
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                MyData data = new MyData() { MyNumber = 11, Name = "StackOverflow" };
    
                XmlSerializer serializerXML = new XmlSerializer(data.GetType());
                serializerXML.Serialize(stream, data);
    
                stream.Seek(0, SeekOrigin.Begin);
    
                data = (MyData)serializerXML.Deserialize(stream);
    
                // We're cheating here, because I assume the SOAP data
                // will be larger than the previous stream. 
                stream.Seek(0, SeekOrigin.Begin);
    
                SoapFormatter serializerSoap = new SoapFormatter();
                serializerSoap.Serialize(stream, data);
    
                stream.Seek(0, SeekOrigin.Begin);
    
                data = (MyData)serializerSoap.Deserialize(stream);
            }
        }
    }

    [Serializable]
        public class SerializeTest
        {
            //public SerializeTest(int a, Func<int> b)
            //{
            //    this.a = a;
            //    this.b = b;
            //}
    
            public SerializeTest()
            {
               
            }
    
            public int A 
            {
                get
                {
                    return a;
                }
    
                set
                {
                    a = value;
                }
            }
            public Func<int> B 
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }
            }
           
    
            #region properties
    
            private int a;
            private Func<int> b;
    
    
    
            #endregion
    
            //serialize itself
            public string Serialize()
            {
                MemoryStream memoryStream = new MemoryStream();
    
                XmlSerializer xs = new XmlSerializer(typeof(SerializeTest));
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
    
                        XmlSerializer xs = new XmlSerializer(typeof(SerializeTest));
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        XmlReader reader = XmlReader.Create(memoryStream);
    
                        SerializeTest currentConfig = (SerializeTest)xs.Deserialize(reader);
    
                        this.a = currentConfig.a;
                        this.b = currentConfig.b;
    
                        w.Close();
                    }
                }
            }
    
        }
    class Program
        {
            static void Main(string[] args)
            {
    
                SerializeTest test = new SerializeTest() { A = 5, B = ()=>67};
                string serializedString =  test.Serialize();
    
    
    }
    }

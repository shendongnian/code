    [Serializable, XmlInclude(typeof(SerializationReferenceHelper))]
    public class TestClass
    {
        public void Test<T>(T x) where T : ITest { }
    }
    
    static class Program
    { 
        static void Main(string[] args)         
        {
            new System.Xml.Serialization.XmlSerializer(typeof(TestClass));
        }
    }

    [Serializable, XmlInclude(ClassLibrary)]
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

    public class MyClass
    {
        public bool doIt()
        {
            int objective = 0;
            return new List<int>() { 1 }.Any(i => i == objective);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            new XmlSerializer(typeof(MyClass)).Serialize(new MemoryStream(), new MyClass());        
        }
    }

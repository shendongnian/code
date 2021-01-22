    public class TestSerialize
    {
        public string Test1;
        public int Test2;
    }
    class Program
    {      
        [STAThread]
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(TestSerialize));
            using (XmlWriter writer = XmlWriter.Create(Guid.NewGuid() + ".xml"))
            {                
                serializer.Serialize(writer, new TestSerialize() { Test1 = "hello", Test2 = 5 });
            }
           
            Console.ReadLine();
        }
    }

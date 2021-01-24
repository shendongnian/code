        [Serializable]
        public class B
        {
            public B()
            {
                this.field1 = "Test";
                this.field2 = new object();
            }
    
            string field1 { get; set; }
            object field2 { get; set; }
        }
    
        [Serializable]
        public class A
        {
            public A()
            {
                this.instance1 = new List<B>() { new B(), new B() };
                this.instance2 = new List<B>() { new B(), new B() };
            }
    
            [XmlElement("list1",typeof(List<B>))]
            List<B> instance1 { get; set; }
    
            [XmlElement("list2",typeof(List<B>))]
            List<B> instance2 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var serializer = new XmlSerializer(typeof(A));
                var a = new A();
                try
                {
                    var fs = new System.IO.FileStream("test.xml", System.IO.FileMode.Create);
                    serializer.Serialize(fs, a);
                    fs.Close();
                    A d = (A)serializer.Deserialize(new System.IO.FileStream("test.xml", System.IO.FileMode.Open));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                Console.ReadLine();
            }
        }

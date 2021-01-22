        public void Test()
        {
            var obj = new Foo2() { Prop1 = "Test", Prop2 = "Test2" };
            SerializeGeneric((Foo1)obj);
        }
        private void SerializeGeneric<T>(T obj)
        {
            StringWriter writer = new StringWriter();    
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(writer, obj);
            Console.WriteLine(writer.ToString());
        }
        public class Foo1
        {
            public string Prop1 { get; set; }
        }
        public class Foo2 : Foo1
        {
            public string Prop2 { get; set; }
        }

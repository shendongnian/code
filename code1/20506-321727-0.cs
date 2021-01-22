        public XDocument Serialize<T>(T source)
        {
            XDocument target = new XDocument();
            XmlSerializer s = new XmlSerializer(typeof(T));
            System.Xml.XmlWriter writer = target.CreateWriter();
            s.Serialize(writer, source);
            writer.Close();
            return target;
        }
        public void Test1()
        {
            MyClass c = new MyClass() { SomeValue = "bar" };
            XDocument doc = Serialize<MyClass>(c);
            Console.WriteLine(doc.ToString());
        }

    public class Program
    {
        public class MyClass
        {
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            var myObj = new MyClass { Name = "My name" };
            var fileName = "data.xml";
            var serializer = new XmlSerializer(typeof(MyClass));
            using (var output = new XmlTextWriter(fileName, Encoding.UTF8))
                serializer.Serialize(output, myObj);
            using (var input = new StreamReader(fileName))
            {
                var deserialized = (MyClass)serializer.Deserialize(input);
                Console.WriteLine(deserialized.Name);
            }
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Mark = new Person()
            {
                Name = "Mark",
                Email = "mark@example.com"
            };
    
            var serializer = new DataContractSerializer(typeof(Person));
    
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };
    
            using (var writer = XmlWriter.Create(Console.Out, settings))
            {
                serializer.WriteObject(writer, Mark);
            }
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

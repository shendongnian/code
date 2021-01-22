    [XmlRoot("Context")]
    public class Context
    {
        public Context() { this.Persons = new Persons(); }
    
        [XmlArray("Persons")]
        [XmlArrayItem("Person")]
        public Persons Persons { get; set; }
    }
    
    public class Persons : List<Human> { }
    
    public class Human
    {
        public Human() { }
        public Human(string name) { Name = name; }
        public string Name { get; set; }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            Context ctx = new Context();
            ctx.Persons.Add(new Human("john"));
            ctx.Persons.Add(new Human("jane"));
    
            var writer = new StringWriter();
            new XmlSerializer(typeof(Context)).Serialize(writer, ctx);
    
            Console.WriteLine(writer.ToString());
        }
    }

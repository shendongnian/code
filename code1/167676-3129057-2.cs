    class Program
    {
        static void Main()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Foo>),
                 new XmlRootAttribute("Flibble"));
            List<Foo> foos = new List<Foo> {
                new Foo {Bar = "abc"},
                new Foo {Bar = "def"}
            };
            ser.Serialize(Console.Out, foos);
        }
    }
    public class Foo
    {
        public string Bar { get; set; }
    }

    public enum Simple { one, two, three }
    public class Foo
    {
        public Simple Simple { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = XmlWriter.Create(Console.OpenStandardOutput()))
            {
                var foo = new Foo
                {
                    Simple = Simple.three
                };
                var serializer = new XmlSerializer(foo.GetType());
                serializer.Serialize(writer, foo);
            }
        }
    }

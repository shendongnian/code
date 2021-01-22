        class Program
        {
            static void Main(string[] args)
            {
                var foo = new Foo(10, "test", new Bar("Detail 1"), new Bar("Detail 2"));
    
                var clonedFoo = foo.Clone();
    
                Console.WriteLine("Id {0} Bar count {1}", clonedFoo.Id, clonedFoo.Bars.Count());
            }
        }
    
        public static class ClonerExtensions
        {
            public static TObject Clone<TObject>(this TObject toClone)
            {
                var formatter = new BinaryFormatter();
    
                using (var memoryStream = new MemoryStream())
                {
                    formatter.Serialize(memoryStream, toClone);
    
                    memoryStream.Position = 0;
    
                    return (TObject) formatter.Deserialize(memoryStream);
                }
            }
        }
    
        [Serializable]
        public class Foo
        {
            public int Id { get; private set; }
    
            public string Name { get; private set; }
    
            public IEnumerable<Bar> Bars { get; private set; }
    
            public Foo(int id, string name, params Bar[] bars)
            {
                Id = id;
                Name = name;
                Bars = bars;
            }
        }
    
        [Serializable]
        public class Bar
        {
            public string Detail { get; private set; }
    
            public Bar(string detail)
            {
                Detail = detail;
            }
        }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new NullableIntConverter());
            using (var reader = new StringReader(@"{""Foo"":null}"))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var pony = serializer.Deserialize<Pony>(jsonReader);
                Console.WriteLine(pony.Foo);
            }
        }
    }

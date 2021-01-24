    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Test>
            {
                new Test() {Hello = "Hi"},
                new TestDerived() {Hello = "hello", Second = "World"}
            };
            var settings = new JsonSerializerSettings() 
            {
                 TypeNameHandling = TypeNameHandling.Objects
            };
            var text = JsonConvert.SerializeObject(items, settings);
            var data = JsonConvert.DeserializeObject<IEnumerable<Test>>(text, settings);
        }
    }
    public class Test
    {
        public string Hello { get; set; }
    }
    public class TestDerived : Test
    {
        public string Second { get; set; }
    }

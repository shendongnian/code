    public class Nested
    {
        [JsonProperty]
        int X { get; }
        [JsonProperty]
        int Y { get; }
        public Nested(int x, int y) { X = x; Y = y; }
    }
    public class C
    {
        [JsonProperty]
        Nested N { get; }
        public C(Nested n) { N = n; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Nested nested = new Nested(1, 2);
            C c = new C(nested);
            string json = JsonConvert.SerializeObject(c);
            C c2 = JsonConvert.DeserializeObject<C>(json);
        }
    }

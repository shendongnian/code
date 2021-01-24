    public class Nested
    {
        public int X { get; }
        public int Y { get; }
        [JsonConstructor]
        Nested(int x, int y) { X=x; Y=y; }
    }
    public class C
    {
        public Nested N { get; }
        [JsonConstructor]
        public C(Nested n) { N = n; }
    }
    const string json = "{ \"n\" : { \"x\" : 1, \"y\" : 2 } }";
    var c = JsonConvert.DeserializeObject<C>(json);

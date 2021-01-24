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
    var c1 = new C(new Nested(1, 2));
    var json = JsonConvert.SerializeObject(c1); // produce something like "{\"n\":{\"x\":1,\"y\":2}}";
    var c2 = JsonConvert.DeserializeObject<C>(json);

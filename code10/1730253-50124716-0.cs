    public interface ICustomLookup
    {
        string X { get; set; }
        string Y { get; set; }
    }
    public class SomeClass : ICustomLookup
    {
        public string X { get; set; }
        public string Y { get; set; }
    }

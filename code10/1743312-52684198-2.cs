    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Fence Fence { get; set; }
    }
    public class Fence
    {
        public int Type { get; set; }
        public FeatureCollection Values { get; set; }
    }

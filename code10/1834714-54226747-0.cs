    public class SomeName
    {
        public List<Hotel> Hotels { get; set; }
    }
    var someName = new SomeName
    {
        Hotels = hotels.Select(x => x.Value).ToList();
    };

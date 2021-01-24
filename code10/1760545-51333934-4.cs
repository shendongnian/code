    public class DataClass
    {
        public int Id { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public DataClass (int id, double? x, double? y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }

    public class AutoPart
    {
        public string Name { get; set; }
        public double Cost { get; set; }
    }
    public class Liquid : AutoPart
    {
        public double Quarts { get; set; }
    }
    public class Tool : AutoPart
    {
        public double SizeInMM { get; set; }
    }

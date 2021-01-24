     public class backDetails
     {
        public double consumed { get; set; }
        public double min_cons { get; set; }
        public double max_cons { get; set; }
        public double totalobjs { get; set; }
        public double totalproces { get; set; }
     }
    public class TheResult
    {
        public backDetails back_1s { get; set; }
        public backDetails back_10s { get; set; }
    }
    public class MyClass
    {
        public TheResult theresult { get; set; }
    }

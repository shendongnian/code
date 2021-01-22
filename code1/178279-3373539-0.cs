    public class Digit { public double Length { get; set; } }
    public class HumanSide
    {
        public Digit Arm { get; set; }
        public Digit Leg { get; set; }
        public Digit MiddleFinger { get; set; }
        public Digit Foot { get; set; }
        public Digit Nose { get; set; }
    }
    public class Human
    {
        public HumanSide Right { get; set; }
        public HumanSide Left { get; set; }
    }

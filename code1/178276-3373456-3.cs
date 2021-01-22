    public class HumanBody
    {
        public Arms Arm { get; private set; }
    }
    public class Arms
    {
        public Arm Left { get; private set; }
        public Arm Right { get; private set; }
    }
    public class Arm
    {
        public double Length { get; private set; }
    }

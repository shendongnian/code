    public class Base
    {
        public int Item1 { get; set; }
        public int Item2 { get; set; }
    }
    public class WithHidden : Base
    {
        hide Item1; // Assuming some new feature "hide" in C#
    }
    public class WithoutHidden : Base { }

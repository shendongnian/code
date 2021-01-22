    public class Child
    {
        public static readonly int Nasty = Parent.Y;
        public static readonly int X = 10;
    }
    public class Parent
    {
        public static readonly int Y = Child.X;
    }

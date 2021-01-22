    public class Base
    {
        public virtual void Go() { Console.WriteLine("in Base"); }
    }
    public class Derived : Base
    {
        public virtual void Go() { Console.WriteLine("in Derived"); }
    }

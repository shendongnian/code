    abstract class Base
    {
        public virtual void foo(string s = "base") { Console.WriteLine("base " + s); }
    }
    class Derived : Base
    {
        public override void foo(string s = "derived") { Console.WriteLine("derived " + s); }
    }
    ...
    Base b = new Derived();
    b.foo();

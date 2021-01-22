    public sealed class Sealed
    {
        public string Message { get; set; }
        public void DoStuff() { }
    }
    public class Derived : Base
    {
        public sealed override void DoStuff() { }
    }
    public class Base
    {
        public string Message { get; set; }
        public virtual void DoStuff() { }
    }
    static void Main()
    {
        Sealed sealedClass = new Sealed();
        sealedClass.DoStuff();
        Derived derivedClass = new Derived();
        derivedClass.DoStuff();
        Base BaseClass = new Base();
        BaseClass.DoStuff();
    }

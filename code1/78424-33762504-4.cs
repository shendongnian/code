    internal abstract class MyBase
    {
        public virtual void F() {}
        public void G() {}
    }
    
    public class MyClass : MyBase // error; inconsistent accessibility
    {
        public override void F() { base.F(); /* ... */ }
    }

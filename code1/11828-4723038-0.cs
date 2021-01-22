    public class Base
    {
       public virtual void Initialize(dynamic stuff) { 
       //...
       }
    }
    public class Derived:Base
    {
       public override void Initialize(dynamic stuff) {
       base.Initialize(stuff);
       //...
       }
    }

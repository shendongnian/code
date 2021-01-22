    public class Base
    {
        public virtual void DoIt()
        {
        }
    }
    
    public class Derived : Base
    {
        public new void DoIt()
        {
        }
    }
    
    Base b = new Derived();
    Derived d = new Derived();
    b.DoIt();                      // Calls Base.DoIt
    d.DoIt();                      // Calls Derived.DoIt

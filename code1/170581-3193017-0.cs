    class Base
    {
      public virtual void VirtualMethod()
      {
        // Insert code here
      }
    }
    
    class Derived : Base
    {
      public override void VirtualMethod()
      {
        // Insert code here
        base.VirtualMethod(); // Explicit call to the base class method
      }
    }

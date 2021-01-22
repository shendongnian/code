     class Base : ICloneable
     { 
         int x;
         protected Base(Base other)
         {
             x = other.x;
         }
         public virtual object Clone()
         {
             return new Base(this);
         }
     }
     class Derived : Base
     { 
         int y;
         protected Derived(Derived other)
              : Base(other)
         {
             y = other.y;
         }
         public override object Clone()
         {
             return new Derived(this);
         }
     }

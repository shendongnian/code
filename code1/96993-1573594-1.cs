     class Base : ICloneable
     { 
         List<int> xs;
         public virtual object Clone()
         {
             Base result = this.MemberwiseClone();
             // xs points to same List object here, but we want
             // a new List object with copy of data
             result.xs = new List<int>(xs);
             return result;
         }
     }
     class Derived : Base
     { 
         List<int> ys;
         public override object Clone()
         {
             // Cast is legal, because MemberwiseClone() will use the
             // actual type of the object to instantiate the copy.
             Derived result = (Derived)base.Clone();
             // ys points to same List object here, but we want
             // a new List object with copy of data
             result.ys = new List<int>(ys);
             return result;
         }
     }

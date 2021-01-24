    class Base : IEquatable<Base> {
      ...
      public override bool Equals(object obj) => 
        this.Equals(obj, o => (X, Y)==(o.X, o.Y));
      public override int GetHashCode() => HashCode.Combine(X, Y);
      // boilerplate
      public bool Equals(Base o) => object.Equals(this, o);
      public static bool operator ==(Base o1, Base o2) => object.Equals(o1, o2);
      public static bool operator !=(Base o1, Base o2) => !object.Equals(o1, o2);
    }
    
    class Derived : Base, IEquatable<Derived> {
      ...
      public override bool Equals(object obj) => 
        this.Equals(obj, o => base.Equals(o as object) && (Z, K) == (o.Z, o.K));
      public override int GetHashCode() => HashCode.Combine(Z, K);
      // boilerplate
      public bool Equals(Derived o) => object.Equals(this, o);
      public static bool operator ==(Derived o1, Derived o2) => object.Equals(o1, o2);
      public static bool operator !=(Derived o1, Derived o2) => !object.Equals(o1, o2);
    }

    class Base : IEquatable<Base>, IImmutable {
      ...
      public override bool Equals(object obj) => 
        this.ImmutableEquals(obj, o => (X, Y)==(o.X, o.Y));
      int? hashCache;
      public override int GetHashCode() => 
        this.ImmutableHash(ref hashCache, (X, Y));
      // boilerplate
      public bool Equals(Base o) => object.Equals(this, o);
      public static bool operator ==(Base o1, Base o2) => object.Equals(o1, o2);
      public static bool operator !=(Base o1, Base o2) => !object.Equals(o1, o2);
    }
    
    class Derived : Base, IEquatable<Derived>, IImmutable {
      ...
      public override bool Equals(object obj) => 
        this.ImmutableEquals(obj, o => base.Equals(obj) && (Z, K) == (o.Z, o.K));
      int? hashCache;
      public override int GetHashCode() => 
        this.ImmutableHash(ref hashCache, (base.GetHashCode(), Z, K));
      // boilerplate
      public bool Equals(Derived o) => object.Equals(this, o);
    }

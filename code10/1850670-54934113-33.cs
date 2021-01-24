    class Base: IEquatable<Base>, IImmutable<Base> {
      public readonly int X;
      readonly int Y;
      public Base(int X, int Y) => (this.X, this.Y) = (X, Y); 
    	
      public bool ValueEquals(Base o) => (X, Y) == (o.X, o.Y);
      public int ValueHashCode() => (X, Y).GetHashCode();
    
      // boilerplate
      public override bool Equals(object obj) => this.ImmutableEquals(obj);
      public bool Equals(Base o) => this.ImmutableEquals(o);
      public static bool operator ==(Base o1, Base o2) => object.Equals(o1, o2);
      public static bool operator !=(Base o1, Base o2) => !object.Equals(o1, o2);
      protected int? hashCache;
      public override int GetHashCode() => this.ImmutableHash(ref hashCache);
    }
    
    class Derived : Base, IEquatable<Derived>, IImmutable<Derived> {
      public readonly int Z;
      readonly int K;
      public Derived(int X, int Y, int Z, int K) : base(X, Y) => (this.Z, this.K) = (Z, K); 
    
      public bool ValueEquals(Derived o) => base.ValueEquals(o) && (Z, K) == (o.Z, o.K);
      public new int ValueHashCode() => (base.ValueHashCode(), Z, K).GetHashCode();
      
      // boilerplate
      public override bool Equals(object obj) => this.ImmutableEquals(obj);
      public bool Equals(Derived o) => this.ImmutableEquals(o); 
      public override int GetHashCode() => this.ImmutableHash(ref hashCache);
    }

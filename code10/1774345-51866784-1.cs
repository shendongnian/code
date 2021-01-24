    class Bar : Foo, IEquatable<Bar> 
    {
      public override bool GetHashcode() { ... }
      protected override bool EqualsImplementation(Foo f) 
      {
        if (object.ReferenceEquals(this, f)) return true;
        Bar b = f as Bar;
        if (b == null) return false;
        if (!base.EqualsImplementation(f)) return false;
        ... We have b and this, not ref equal, both Bars, both
        ... equal according to Foo.  Do the Bar logic here.
      }
      public bool Equals(Bar b) => this.Equals((object)b);
      public static bool Equals(Bar b1, Bar b2) =>
        b1 == null ? b2 == null : b1.Equals(b2);
      public static bool operator ==(Bar b1, Bar b2) => Equals(b1, b2);
      public static bool operator !=(Bar b1, Bar b2) => !(b1 == b2);
      // Note that there is no need to override Equals(object). It
      // already has a correct implementation.
    }

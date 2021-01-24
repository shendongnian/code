    class Bar : Foo, IEquatable<Bar> 
    {
      public override bool GetHashcode() { ... }
      protected override bool EqualsImplementation(Foo f) 
      {
        // Again, take easy outs when you find them.
        if (object.ReferenceEquals(this, f)) return true;
        Bar b = f as Bar;
        if (object.ReferenceEquals(b, null)) return false;
        if (!base.EqualsImplementation(f)) return false;
        ... We have b and this, not ref equal, both Bars, both
        ... equal according to Foo.  Do the Bar logic here.
      }
      // Note that there is no need to override Equals(object). It
      // already has a correct implementation in Foo.
      // And once again we can use the correctness of the previous
      // method to implement the next method.  We need this method
      // to implement IEquatable<Bar>'s contract:
      public bool Equals(Bar b) => this.Equals((object)b);
      // As noted in a comment below, the following are not strictly
      // necessary, as the (Foo, Foo) methods in the base class do
      // the right thing when given two Bars.  However, it might be
      // nice for debugging or self-documenting-code reasons to implement
      // them, and they're easy.  Omit them if you like.
      public static bool Equals(Bar b1, Bar b2) =>
        object.ReferenceEquals(b1, null) ? 
          object.ReferenceEquals(b2, null) : 
          b1.Equals(b2);
      public static bool operator ==(Bar b1, Bar b2) => Equals(b1, b2);
      public static bool operator !=(Bar b1, Bar b2) => !(b1 == b2);
    }

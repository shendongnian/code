    class Foo : IEquatable<Foo> 
    {
      public override bool GetHashcode() { ... }
      protected virtual bool EqualsImplementation(Foo f) 
      {
        if (object.ReferenceEquals(this, f)) return true;
        if (object.ReferenceEquals(f, null)) return false;
        ... We now have this and f as valid, not ref equal Foos.
        ... implement the comparison logic here
      }
      // Now implement Equals(object) by using EqualsImplementation():
      public bool Equals(object f) => 
        (!object.ReferenceEquals(f, null)) &&  
        (f.GetType() == this.GetType()) &&
        this.EqualsImplementation((Foo)f);
      // Now implement Equals(Foo) using Equals(object)
      public bool Equals(Foo f) => this.Equals((object)f);
      // Now implement Equals(Foo, Foo) using Equals(Foo)
      public static bool Equals(Foo f1, Foo f2) =>
        object.ReferenceEquals(f1, null) ? 
          object.ReferenceEquals(f2, null) :
          f1.Equals(f2);
      // You see how this goes. Every subsequent method uses
      // the correctness of the previous method to ensure its
      // correctness in turn!
      public static bool operator ==(Foo f1, Foo f2) => 
        Equals(f1, f2);
      public static bool operator !=(Foo f1, Foo f2) => 
        !(f1 == f2);
      ...
    }

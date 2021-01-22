    class Foo : IEquatable<Foo>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Foo);
        }
        public bool Equals(Foo other)
        {
            if (object.ReferenceEquals(other, null)) return false;
            // Optional early out
            if (object.ReferenceEquals(this, other)) return true; 
            // Compare fields here
        }
        public static bool Equals(Foo a, Foo b)
        {
            if (ReferenceEquals(a, null)) return ReferenceEquals(b, null);
            return a.Equals(b);
        }
        public static bool operator ==(Foo a, Foo b)
        {
            return Equals(a, b);
        }
        public static bool operator !=(Foo a, Foo b)
        {
            return !Equals(a, b);
        }
    }

    public class Foo : IEquatable<Foo>
    {
        public Int32 Id { get; set; }
        public static Boolean operator ==(Foo a, Foo b)
        {
            return Object.ReferenceEquals(a, b)
                || !Object.ReferenceEquals(a, null)
                && !Object.ReferenceEquals(b, null)
                && (a.Id == b.Id);
        }
        public static Boolean operator !=(Foo a, Foo b)
        {
            return !(a == b);
        }
        public Boolean Equals(Foo other)
        {
            return this == other;
        }
        public override Boolean Equals(Object obj)
        {
            return this == obj as Foo;
        }
        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

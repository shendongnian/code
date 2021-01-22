    public class Foo : IEquatable<Foo>
    {
        public Int32 Id { get; set; }
        public override Boolean Equals(Object obj)
        {
            return Object.ReferenceEquals(this, obj)
                || !Object.ReferenceEquals(obj as Foo, null)
                && (this.Id == ((Foo)obj).Id);
        }
        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public static Boolean operator ==(Foo a, Foo b)
        {
            return Object.Equals(a, b);
        }
        public static Boolean operator !=(Foo a, Foo b)
        {
            return !Object.Equals(a, b);
        }
        public Boolean Equals(Foo other)
        {
            return Object.Equals(this, other);
        }
    }

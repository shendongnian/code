    public class Foo : IEquatable<Foo>
    {
        public Int32 Id { get; set; }
        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override Boolean Equals(Object obj)
        {
            return !Object.ReferenceEquals(obj as Foo, null)
                && (this.Id == ((Foo)obj).Id);
            // Alternative casting to Object to use == operator.
            return ((Object)(obj as Foo) != null) && (this.Id == ((Foo)obj).Id);
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

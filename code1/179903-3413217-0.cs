    public class Base : IComparable<Base>
    {
        public virtual int CompareTo(Base other)
        {
            // do comparison
        }
    }
    public class Derived : Base, IComparable<Derived>
    {
        public int CompareTo(Derived other)
        {
            // do comparison
        }
        public override int CompareTo(Base other)
        {
            if (other is Derived)
                return CompareTo((Derived) other);
            return base.CompareTo(other);
        }
    }

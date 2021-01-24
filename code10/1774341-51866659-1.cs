    class Bar : Foo
    {
        public int bar;
        public override bool Equals(object other)
        {
            return other is Bar otherBar && bar.Equals(otherBar.bar) && base.Equals(other);
        }
        public static bool operator ==(Bar first, Bar second)
        {
            if ((object)first == null) {
                return (object)second == null;
            }
            return first.Equals(second) && second.Equals(first); // In case one is more derived.
        }
        public static bool operator !=(Bar first, Bar second)
        {
            return !(first == second);
        }
        public override int GetHashCode()
        {
            unchecked {
                return (base.GetHashCode() * 53) ^ bar.GetHashCode();
            }
        }
    }

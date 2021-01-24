    class Foo
    {
        public int foo;
        public override bool Equals(object other)
        {
            return other is Foo otherFoo && foo.Equals(otherFoo.foo);
        }
        public static bool operator ==(Foo first, Foo second)
        {
            if ((object)first == null) {
                return (object)second == null;
            }
            return first.Equals(second) && second.Equals(first);
        }
        public static bool operator !=(Foo first, Foo second)
        {
            return !(first == second);
        }
        public override int GetHashCode()
        {
            unchecked {
                return foo.GetHashCode();
            }
        }
    }

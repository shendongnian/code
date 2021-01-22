    public struct Foo
    {
        private readonly int x;
        public Foo(int x)
        {
            this.x = x;
        }
        
        public override string ToString()
        {
            return string.Format("Foo {{x={0}}}", x);
        }
        public override int GetHashCode()
        {
            return x.GetHashCode();
        }
        public override bool Equals(Object obj)
        {
            return x.Equals(obj);
        }
        public static bool operator ==(Foo a, Foo b)
        {
            return a.x == b.x;
        }
        public static bool operator !=(Foo a, Foo b)
        {
            return a.x != b.x;
        }
        [Obsolete("The result of the expression is always 'false' since a value of type 'Foo' is never equal to 'null'", true)]
        public static bool operator ==(Foo a, Foo? b)
        {
            return false;
        }
        [Obsolete("The result of the expression is always 'true' since a value of type 'Foo' is never equal to 'null'", true)]
        public static bool operator !=(Foo a, Foo? b)
        {
            return true;
        }
        [Obsolete("The result of the expression is always 'false' since a value of type 'Foo' is never equal to 'null'", true)]
        public static bool operator ==(Foo? a, Foo b)
        {
            return false;
        }
        [Obsolete("The result of the expression is always 'true' since a value of type 'Foo' is never equal to 'null'", true)]
        public static bool operator !=(Foo? a, Foo b)
        {
            return true;
        }
    }

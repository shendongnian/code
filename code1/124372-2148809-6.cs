    public struct Foo
    {
        private readonly string key1;
        private readonly string key2;
    
        public string Key1
        {
            get
            {
                return this.key1;
            }
        }
    
        public string Key2
        {
            get
            {
                return this.key2;
            }
        }
    
        public Foo(string key1, string key2)
        {
            this.key1 = key1;
            this.key2 = key2;
        }
    
        public static bool operator ==(Foo foo1, Foo foo2)
        {
            return foo1.Equals(foo2);
        }
    
        public static bool operator !=(Foo foo1, Foo foo2)
        {
            return !(foo1 == foo2);
        }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Foo))
            {
                return false;
            }
    
            Foo foo = (Foo)obj;
    
            return this.key1.Equals(foo.Key1) && this.key2.Equals(foo.Key2);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (23 * hash) + (this.key1 == null ? 0 : this.key1.GetHashCode());
                return (31 * hash) + (this.key2 == null ? 0 : this.key2.GetHashCode());
            }
        }
    
        public override string ToString()
        {
            return (this.key1 == null ? string.Empty : this.key1.ToString() + ",") + (this.key2 == null ? string.Empty : this.key2.ToString());
        }
    }

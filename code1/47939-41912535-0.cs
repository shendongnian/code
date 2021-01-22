    class Foo
    {
        public readonly Guid id;
        public string description;
        public override bool Equals(object obj)
        {
            return ((Foo)obj).id == id;
        }
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }

    public struct MyEnum : IEquatable<MyEnum>
    {
        private readonly string name;
        private MyEnum(string name) { name = name; }
        
        public string Name
        {
            // ensure observable pureness and true valuetype behavior of our enum
            get { return name ?? nameof(Bork); } // <- by choosing a default here.
        }
        // our enum values:
        public static readonly MyEnum Bork;
        public static readonly MyEnum Foo;
        public static readonly MyEnum Bar;
        public static readonly MyEnum Bas;
        // automatic initialization:
        static MyEnum()
        {
            FieldInfo[] values = typeof(MyEnum).GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (var value in values)
                value.SetValue(null, new MyEnum(value.Name));
        }
        /* don't forget these: */
        public override bool Equals(object obj)
        {
            return obj is MyEnum && Equals((MyEnum)obj);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return Name.ToString();
        }
        public bool Equals(MyEnum other)
        {
            return Name.Equals(other.Name);
        }
        public static bool operator ==(MyEnum left, MyEnum right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MyEnum left, MyEnum right)
        {
            return !left.Equals(right);
        }
    }

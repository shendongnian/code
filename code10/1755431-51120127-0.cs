    struct MyStruct : IEquatable<MyStruct>
    {
        public int A { get; set; }
    
        public int B { get; set; }
    
        public bool Equals(MyStruct other)
        {
            return A == other.A && B == other.B;
        }
    
        public override bool Equals(object obj)
        {
            if (!(obj is MyStruct)) return false;
            return ((MyStruct)obj).Equals(this);
        }
    
        public override int GetHashCode()
        {
            return (A, B).GetHashCode();
        }
    }

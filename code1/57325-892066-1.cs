    class a
    {
        public static bool operator ==(a x, b y)
        {
            return x == y.a;
        }
        public static bool operator !=(a x, b y)
        {
            return !(x == y);
        }
    }
    
    class b
    {
        public a a{get;set;}
        public static implicit operator a(b b)
        {
            return b.a;
        }
    }

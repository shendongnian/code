    class A
    {
        public static int CalcHashCode(A obj)
        {
            return 1;
        }
        public override int GetHashCode()
        {
            return CalcHashCode(this);
        }
    }
    class B : A
    {
        public override int GetHashCode()
        {
            return A.CalcHashCode(this);
        }
    }

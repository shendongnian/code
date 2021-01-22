    class A
    {
        /*elide the stuff you already have*/
        protected int GetBaseHashCode()
        {
            return base.GetHashCode();
        }
    }
    class A : B
    {
        /*elide stuff already in example*/
        public override int GetHashCode()
        {
            return num + GetBaseHashCode();
        }
    }

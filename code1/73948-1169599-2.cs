    class AbsClassB : AbsClass
    {
        public override double Top { get { return ((ConcClassB)this).Top } }
        public override double Bottom { get { return ((ConcClassB)this).Bottom } }
    }
    class ConcClassB :  AbsClassB
    {
        new public double Top
        {
            get { ... }
            set { ... }
        }
        new public double Bottom
        {
            get { ... }
            set { ... }
        }
    }

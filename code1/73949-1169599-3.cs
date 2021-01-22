    abstract class AbsClass : IClass
    {
        public double Top
        {
            get { return GetTop(); }
        }
    
        public double Bottom
        {
            get { return GetBottom(); }
        }
        protected abstract double GetTop();
        protected abstract double GetBottom();
    }
    class ConcClassB :  AbsClass
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
        protected override double GetTop()
        {
            return Top;
        }
        protected override double GetBottom()
        {
            return Bottom;
        }
    }

    abstract class A
    {
        public abstract string X { get; set; }
    }
    class D : A
    {
        private static string _x;
        public override string X
        {
            get { return _x; }
            set { _x = value; }
        }
    }

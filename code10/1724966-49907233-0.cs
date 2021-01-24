    public class Complex : Cartesian
    {
        public int I { get; set; }
        //public Complex(int x, int y, int i) : base(x, y)
        public Complex(int i) : base.ctorp
        {
            I = i;
        }
    }

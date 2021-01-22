    public class Complex
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }
        public static implicit operator Complex(int value)
        {
            Complex x = new Complex();
            x.Real = value;
            return x;
        }
    }

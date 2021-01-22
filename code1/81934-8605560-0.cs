    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public T Process<T>(Func<object, T> func)
        {
            return func(new
            {
                Real = this.Real,
                Imaginary = this.Imaginary,
            });
        }
        public override int GetHashCode()
        {
            return this.Process(obj => obj.GetHashCode());
        }
        public override string ToString()
        {
            return this.Process(obj => obj.ToString());
        }
    }

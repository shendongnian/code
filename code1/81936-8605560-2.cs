    public class Complex : DataClass
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        protected override TOutput Execute<TParameter, TOutput>(
            Func<object, TParameter, TOutput> function,
            TParameter other)
        {
            return function(new
            {
                Real = this.Real,
                Imaginary = this.Imaginary,
            }, other);
        }
    }

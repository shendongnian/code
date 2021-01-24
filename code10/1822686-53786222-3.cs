    public SomeObject
    {
        private readonly Func<double, double> _calculate;
        private readonly Func<double, double> _derivate;
        public SomeObject(IMathFunction mathFunction)
        {
            _calculate = mathFunction.Calculate;
            _derivate = mathFunction.Derivate;
        }
        public double SomeWork(double input, double step)
        {
            var f = _calculate(input);
            var dv = _derivate(input);
            return f - (dv * step);
        }
    }

    public SomeObject<TMathFunction> where TMathFunction: IMathFunction 
    {
      private readonly TMathFunction mathFunction_;
    
      public double SomeWork(double input, double step)
      {
        var f = mathFunction_.Calculate(input);
        var dv = mathFunction_.Derivate(input);
        return f - (dv * step);
      }
    }

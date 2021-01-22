    public static Complex operator +(Complex cmp, int value)
    {
      Complex x = new Complex();
      x.Real = cmp.Real + value;
      x.Imaginary = cmp.Imaginary;
      return x;
     }

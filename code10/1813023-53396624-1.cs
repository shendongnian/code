	public static Complex Tan(Complex value)
	{
		if (Math.Abs(value.Imaginary) > 20)
			return new Complex(0, Math.Sign(value.Imaginary));
		else
			return Complex.Tan(value);
	}

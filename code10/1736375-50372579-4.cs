    public static T ThrowIfZero<T>(this T argument) where T : struct
	{
		bool isZero = Math.Abs(Decimal.Compare(0.0m, Convert.ToDecimal(argument))) < Double.Epsilon;
		if (isZero)
			throw new ArgumentOutOfRangeException("some error here");
		return argument;
	}

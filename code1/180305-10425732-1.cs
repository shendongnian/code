	public static class DoubleComparerExtensions
	{
		public static bool AlmostEquals(this double left, double right, long representationTolerance)
		{
			long leftAsBits = left.ToBits2Complement();
			long rightAsBits = right.ToBits2Complement();
			long floatingPointRepresentationsDiff = Math.Abs(leftAsBits - rightAsBits);
			return (floatingPointRepresentationsDiff <= representationTolerance);
		}
		private static unsafe long ToBits2Complement(this double value)
		{
			double* valueAsDoublePtr = &value;
			long* valueAsLongPtr = (long*)valueAsDoublePtr;
			long valueAsLong = *valueAsLongPtr;
			return valueAsLong < 0
				? (long)(0x8000000000000000 - (ulong)valueAsLong)
				: valueAsLong;
		}
	}

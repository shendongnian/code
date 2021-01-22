	public static class Int32Methods
	{
		public static int DivideByAndRoundUp(this int number)
		{
			return (int)(((float)number / (float)number) + 0.5f);
		}
	}

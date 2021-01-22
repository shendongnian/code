        private static int GetDigitCount(dynamic number)
		{
			dynamic digit = 0;
			number = Math.Abs(number);
			while ((dynamic)Math.Pow(10, digit++) <= number)
				;
			return digit - 1;
		}
        public static int GetDigit(this int number)
		{
			return GetDigitCount(number);
		}
		public static int GetDigit(this long number)
		{
			return GetDigitCount(number);
		}

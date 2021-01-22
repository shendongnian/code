	public static class Enums<TEnum> where TEnum : struct, IComparable, IFormattable, IConvertible
	{
		static Enums()
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new InvalidOperationException();
			}
		}
    }

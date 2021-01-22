	public static class Enum<TEnum, T>
		where TEnum : struct
	{
		private static Func<T, TEnum> _convert = CreateDelegate();
		private static Func<T, TEnum> CreateDelegate()
		{
			Func<TEnum, TEnum> identity = Identity;
			return Delegate.CreateDelegate(typeof(Func<T, TEnum>), identity.Method) as Func<T, TEnum>;
		}
		public static TEnum Identity(TEnum x) { return x; }
		public static TEnum Convert(T @enum)
		{
			return _convert(@enum);
		}
	}

	struct MyPair<TKey, TValue> : IConvertable
	{
		public readonly TKey Key;
		public readonly TValue Value;
		public MyPair(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
		// I just used the smart-tag on IConvertable to get all these...
		// public X ToX(IFormatProvider provider) { throw new InvalidCastException(); }
		...
		public object ToType(Type conversionType, IFormatProvider provider)
		{
			if (typeof(MyPair<TKey, TValue>).GUID == conversionType.GUID)
				return this;
			throw new InvalidCastException();
		}
	}

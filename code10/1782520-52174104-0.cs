	class ReferenceTo<T>
	{
		public ReferenceTo(T source)
		{
			Value = source;
		}
		public T Value { get; set; }
	}

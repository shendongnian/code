	class Ref<T>
	{
		public T Value { get; set; }
		public Ref(T item)
		{
			Value = item;
		}
		public override string ToString()
		{
			return Value.ToString();
		}
		public static implicit operator T(Ref<T> source)
		{
			return source.Value;
		}
	}

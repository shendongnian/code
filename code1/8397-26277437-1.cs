	public static T[] GenerateInitializedArray<T>(int size, Func<int, T> factory)
	{
		var arr = new T[size];
		for (int i = 0; i < arr.Length; i++)
		{
			arr[i] = factory(i);
		}
		return arr;
	}

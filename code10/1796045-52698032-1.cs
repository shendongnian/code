    public static List<T> SArrayEnumToList<T>(int[] arr)
    {
		if (!typeof (T).IsEnum)
			throw new ArgumentException("T must be of type System.Enum");
        // cast to object first
		return arr.Cast<object>()
                  .Cast<T>()
                  .ToList();
    }

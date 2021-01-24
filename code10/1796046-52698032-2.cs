    public static List<T> SArrayEnumToList<T>(int[] arr) where T : struct, IConvertible
    {
		if (!typeof (T).IsEnum)
			throw new ArgumentException("T must be of type System.Enum");
        // cast to object first
		return arr.Cast<object>()
                  .Cast<T>()
                  .ToList();
    }
    // or
	public enum Test
	{
		blah,
		balh2,
		blah3
	}
    ...
    var results = ((Test[])(object)values).ToList();

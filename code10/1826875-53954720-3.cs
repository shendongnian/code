	public static IEnumerable<T> EnumerateMask<T>(Enum mask)
		=> Enum.GetValues(typeof (T))
               .Cast<Enum>()
               .Where(mask.HasFlag)
               .Cast<T>()
               .Skip(1);

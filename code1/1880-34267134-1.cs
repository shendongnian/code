		public static bool TryParse<T>(string value, out T result)
			where T : struct
		{
			var cacheKey = "Enum_" + typeof(T).FullName;
            // [Use MemoryCache to retrieve or create&store a dictionary for this enum, permanently or temporarily.
            // [Implementation off-topic.]
			var enumDictionary = CacheHelper.GetCacheItem(cacheKey, CreateEnumDictionary<T>, EnumCacheExpiration);
			return enumDictionary.TryGetValue(value.Trim(), out result);
		}
		private static Dictionary<string, T> CreateEnumDictionary<T>()
		{
			return Enum.GetValues(typeof(T))
				.Cast<T>()
				.ToDictionary(value => value.ToString(), value => value, StringComparer.OrdinalIgnoreCase);
		}

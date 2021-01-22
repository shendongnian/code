	private DateTime GetCacheUtcExpiryDateTime(string cacheKey)
	{
		object cacheEntry = Cache.GetType().GetMethod("Get", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(Cache, new object[] { cacheKey, 1 });
		PropertyInfo utcExpiresProperty = cacheEntry.GetType().GetProperty("UtcExpires", BindingFlags.NonPublic | BindingFlags.Instance);
		DateTime utcExpiresValue = (DateTime)utcExpiresProperty.GetValue(cacheEntry, null);
		return utcExpiresValue;
	}

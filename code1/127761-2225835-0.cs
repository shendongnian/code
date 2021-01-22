    	public static IEnumerable<T> TakeByDistinctKey<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keyFunc, int numKeys) {
		if(keyFunc == null) {
			throw new ArgumentNullException("keyFunc");
		}
		List<TKey> keys = new List<TKey>();
		foreach(T item in source) {
			TKey key = keyFunc(item);
			if(keys.Contains(key)) {
				// one if the first n keys, yield
				yield return item;
			} else if(keys.Count < numKeys) {
				// new key, but still one of the first n seen, yield
				keys.Add(key);
				yield return item;
			}
			// have enough distinct keys, just keep going to return all of the items with those keys
		}
	}

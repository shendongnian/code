	public static TValue GetValueOrDefault<TKey, TValue>
        (this Dictionary<TKey, TValue> dictionary, TKey key, 
         TValue defaultValue = default(TValue))
	{
		if (dictionary == null) { throw new ArgumentNullException(nameof(dictionary)); }
		if (key == null) { throw new ArgumentNullException(nameof(key)); } 
		TValue value;
		return dictionary.TryGetValue(key, out value) ? value : defaultValue;
	}
	
	
	var outputs = inputs
					  .SelectMany(input =>
					    input
						  .A.Keys 				// all key from A
						  .Union(input.B.Keys)  // + all key from B without the duplicate
						  .Select(k =>
							new Output
							 {
								 Key = k,
								 A = input.A.GetValueOrDefault(k),
								 B = input.B.GetValueOrDefault(k)
							 }
						   ) 
					   );

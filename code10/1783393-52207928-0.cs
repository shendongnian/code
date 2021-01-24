	public static class Extensions {
		public static IEnumerable<TResult> FullOuterJoin<TA, TB, TKey, TResult>(
			this IEnumerable<TA> a,
			IEnumerable<TB> b,
			Func<TA, TKey> selectKeyA,
			Func<TB, TKey> selectKeyB,
			Func<TA, TB, TKey, TResult> projection,
			TA defaultA = default(TA),
			TB defaultB = default(TB),
			IEqualityComparer<TKey> cmp = null) {
			
			cmp = cmp ?? EqualityComparer<TKey>.Default;
			var adict = a.ToDictionary(selectKeyA, cmp);
			var bdict = b.ToDictionary(selectKeyB, cmp);
	
			var keys = new HashSet<TKey>(adict.Keys, cmp);
			keys.UnionWith(bdict.Keys);
	
			var join = from key in keys
				       let xa = adict.GetOrDefault(key, defaultA)
				       let xb = bdict.GetOrDefault(key, defaultB)
				       select projection(xa, xb, key);
            return join;
		}
		
		public static T GetOrDefault<K, T>(this IDictionary<K, T> d, K k, T def = default(T)) 
			=> d.TryGetValue(k, out T value) ? value : def;
	}

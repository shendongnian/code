	static class ExtensionMethods
	{
		static public void MergeInto<TKey,TValue>(this Dictionary<TKey,TValue> rhs, Dictionary<TKey,TValue> lhs)
		{
			foreach (var key in rhs.Keys.Union(lhs.Keys).Distinct().ToList())
			{
				if (!rhs.ContainsKey(key))
				{
					lhs.Remove(key);
					continue;
				}
				if (!lhs.ContainsKey(key))
				{
					lhs.Add(key, rhs[key]);
					continue;
				}
				lhs[key] = rhs[key];
			}
		}
	}

	/// <summary> Removes all duplicate values after the first occurrence. </summary>
	public static void RemoveDuplicates<T, V> (this Dictionary<T, V> dict)
	{
		List<V> L = new List<V> ();
		int i = 0;
		while (i < dict.Count)
		{
			KeyValuePair<T, V> p = dict.ElementAt (i);
			if (!L.Contains (p.Value))
			{
				L.Add (p.Value);
				i++;
			}
			else
			{
				dict.Remove (p.Key);
			}
		}
	}

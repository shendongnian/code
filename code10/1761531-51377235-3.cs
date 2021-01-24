	/// <summary> Removes all values which have any duplicates. </summary>
	public static void RemoveAllDuplicates<T, V> (this Dictionary<T, V> dict)
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
				dict.Where (j => Equals (j.Value, p.Value)).ToList ().ForEach (j => dict.Remove (j.Key));
			}
		}
	}

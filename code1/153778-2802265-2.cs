	if (IsDictionary(fieldObject)) //key-value type collection?
	{
		System.Collections.IDictionary dictionary = fieldObject as System.Collections.IDictionary;
		foreach (object _ob in dictionary.Values)
		{
			//do work
		}
		// dictionary.Clear();
	}
	else //normal collection
	{
		if (IsCollection(fieldObject))
		{
			System.Collections.ICollection coll = fieldObject as System.Collections.ICollection;
			foreach (object _ob in coll)
			{
				//do work
			}
			if (IsList(fieldObject))
			{
				//System.Collections.IList list = fieldObject as System.Collections.IList;
				//list.Clear(); // <--- List's function, not Collection's.
			}
		}
	}

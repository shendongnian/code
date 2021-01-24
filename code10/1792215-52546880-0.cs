	public IEnumerable<FilterType> EnumerateRecursively()
	{
		yield return this;
		
		foreach (var item in fl)
		{
			foreach (var subItem in item.EnumerateRecursively())
			{
				yield return subItem;
			}
		}
	}

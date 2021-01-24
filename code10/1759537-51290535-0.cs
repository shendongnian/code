	public IEnumerator<PropertyInfo> GetEnumerator()
	{
		foreach (var property in typeof(Customer).GetProperties())
		{
			yield return property;
		}
	}

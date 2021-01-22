    public new IEnumerator<T> GetEnumerator()
	{
		foreach (T type in this)
		{
			yield return type;
		}
	}
 

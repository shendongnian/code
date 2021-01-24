	public Object GetObjectFromDict(string foo)
	{
		if (someDict.ContainsKey(foo))
		{
			return someDict[foo];
		}
		return null;
	}

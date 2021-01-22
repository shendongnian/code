    private T GetFromSessionStruct<T>(string key, T defaultValue = default(T)) where T : struct 
	{
		object obj = HttpContext.Current.Session[key];
		if (obj == null)
		{
			return defaultValue;
		}
		return (T)obj;
	}
	private T GetFromSession<T>(string key) where T : class
	{
		object obj = HttpContext.Current.Session[key];
		return (T)obj;
	}
	private T GetFromSessionOrDefault<T>(string key, T defaultValue = null) where T : class
	{
		object obj = HttpContext.Current.Session[key];
		if (obj == null)
		{
			return defaultValue ?? default(T);
		}
		return (T)obj;
	}
	private void SetInSession<T>(string key, T value)
	{
		if (value == null)
		{
			HttpContext.Current.Session.Remove(key);
		}
		else
		{
			HttpContext.Current.Session[key] = value;
		}
	}

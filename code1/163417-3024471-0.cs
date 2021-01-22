	public static IEnumerable<IEnumerable<T>> GetCollections<T>(object obj)
	{
		if(obj == null) throw new ArgumentNullException("obj");
		var type = obj.GetType();
		var res = new List<IEnumerable<T>>();
		foreach(var prop in type.GetProperties())
		{
			// is IEnumerable<T>?
			if(typeof(IEnumerable<T>).IsAssignableFrom(prop.PropertyType))
			{
				var get = prop.GetGetMethod();
				if(!get.IsStatic && get.GetParameters().Length == 0) // skip indexed & static
				{
					var collection = (IEnumerable<T>)get.Invoke(obj, null);
					if(collection != null) res.Add(collection);
				}
			}
		}
		return res;
	}

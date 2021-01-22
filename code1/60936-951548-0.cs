    	public List<T> TypedList<T>() where T : new()
		{
			object obj = new object();
			T typObj = new T();
			obj = typObj;
			List<T> list = new List<T>();
			list.Add((T)obj);
			return list;
		}

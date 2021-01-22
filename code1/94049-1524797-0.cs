    		static T Map<T>(object obj, Func<object, T> map, T def)
		{
			if (obj != null)
			{
				return map(obj);
			}
			return def;
		}
		static T Map<T>(object obj, Func<object, T> map)
		{
			return Map<T>(obj, map, default(T));
		}

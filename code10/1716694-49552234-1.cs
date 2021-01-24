	private void Recursion(object obj)
	{
		var props = GetProperties(obj);
		foreach (var item in props)
		{
			if (item.PropertyType == typeof(string))
			{
				var name = item.Name;
				var value = item.GetValue(obj)?.ToString();
			}
			else if (item.PropertyType == typeof(List<DetailClass>))
			{
				var test = (List<DetailClass>) item.GetValue(obj);
				foreach (var t in test)
				{
					Recursion(t);
				}                    
			}
		}
	}

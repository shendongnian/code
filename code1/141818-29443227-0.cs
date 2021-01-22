    public object GetPropertyValue(object obj, string propertyName)
	{
		var _propertyNames = propertyName.Split('.');
		
		for (var i = 0; i < _propertyNames.Length; i++)
		{
			if (obj != null)
			{
				var _propertyInfo = obj.GetType().GetProperty(_propertyNames[i]);
				if (_propertyInfo != null)
					obj = _propertyInfo.GetValue(obj);
				else
					obj = null;
			}
		}
		
		return obj;
	}

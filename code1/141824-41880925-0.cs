	public static object GetPropertyVal(this object obj, string name) {
		if (obj == null)
			return null;
		var parts = name.Split(new[] { '.' }, 2);
		var prop = obj.GetType().GetProperty(parts[0]);
		if (prop == null)
			throw new ArgumentException($"{parts[0]} is not a property of {obj.GetType().FullName}.");
		var val = prop.GetValue(obj);
		return (parts.Length == 1) ? val : val.GetPropertyVal(parts[1]);
	}

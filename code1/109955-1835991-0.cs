	IDictionary<string, string> GetProps<T>(T DataObject)
	{
		if(null == DataObject)
			return new Dictionary<string, string>();
		var nullableProperties = 
			from property in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
			from accessor in property.GetAccessors(false)
			let returnType = accessor.ReturnType
			where returnType.IsGenericType
			&& returnType.GetGenericTypeDefinition() == typeof(Nullable<>)
			&& accessor.GetParameters().Length == 0
			select new { Name=property.Name, Getter=accessor};
		return nullableProperties.ToDictionary(
			x => x.Name,
			x => x.Getter.Invoke(DataObject, null).ToString());
	}

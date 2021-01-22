	Func<Type, List<Type>> f = ty =>
	{
		var tysReturn = new List<Type>();
		tysReturn.Add(ty.BaseType);
		tysReturn.AddRange(ty.GetInterfaces());
		return tysReturn;
	};

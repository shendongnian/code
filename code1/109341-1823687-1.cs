    Func<Type, List<Type>> f = ty =>
    {
        var tysReturn = new List<Type>();
        if (ty.BaseType != null)
        {
            tysReturn.Add(ty.BaseType);
        }
        tysReturn.AddRange(ty.GetInterfaces());
        return tysReturn;
    };

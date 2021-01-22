    //Checking if T implements IDeletableObject
    if (typeof(IDeletableObject).IsAssignableFrom(typeof(T)))
    {
        //a
        var parameter = Expression.Parameter(typeof(T), "a");
        //a.IsDeleted == false
        var where = parameter.EqualExpression("IsDeleted", false);
        //a => a.IsDeleted == false
        var condition = Expression.Lambda<Func<T, bool>>(where, parameter);
        list = list.Where(condition);
    }

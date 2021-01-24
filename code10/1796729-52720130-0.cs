    var parameter = Expression.Parameter(typeof(MyModel), "x");
    var body = Expression.PropertyOrField(parameter, nameof(MyModel.Property1));
    var methodCall = Expression.Call(typeof(string), nameof(string.IsNullOrWhiteSpace), null, body);
    var nullOrWhiteSpaceComparison = Expression.Not(methodCall);
    var lambda = Expression.Lambda<Func<MyModel, bool>>(nullOrWhiteSpaceComparison, parameter);

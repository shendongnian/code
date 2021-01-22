       MethodInfo method = typeof(Queryable).GetMethods()
            .Where(m => m.Name == "Any" && m.GetParameters().Length == 2)
            .Single().MakeGenericMethod(typeof(Tank));
        ParameterExpression vehicleParameter = Expression.Parameter(
            typeof(Vehicle), "v");
        var vehicleFunc = Expression.Lambda<Func<Vehicle, bool>>(
            Expression.Call(
                method,
                Expression.Property(
                    vehicleParameter,
                    typeof(Vehicle).GetProperty("Tank")),
                tankFunction), vehicleParameter);

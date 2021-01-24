    var parameter = Expression.Parameter(typeof(ReadsModel), "x");
    var body = Expression.Call(
    	typeof(Enumerable), // class containing the static method
    	nameof(Enumerable.Any), // method name
    	new Type[] { typeof(RemarksModel) }, // generic type arguments
    	Expression.Property(parameter, "Remarks"), lambda // method arguments
    );
    var predicate = Expression.Lambda<Func<ReadsModel, bool>>(body, parameter);

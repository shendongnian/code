	var typeClassA = typeof(ClassA);
	var typeClassB = typeof(ClassB);
	
	var parameterExpressionX = Expression.Parameter(typeClassB, "x");
	var newExpression = Expression.New(typeClassB);
	var paramDPropertyExpression = Expression.Property(parameterExpressionX, "ParamD");
	var paramDMemberBinding = Expression.Bind(typeClassB.GetProperty("ParamD"), paramDPropertyExpression);
	var paramEPropertyExpression = Expression.Property(parameterExpressionX, "ParamE");
	var paramEMemberBinding = Expression.Bind(typeClassB.GetProperty("ParamE"), paramEPropertyExpression);
	var memberInitExpression = Expression.MemberInit(
		newExpression,
		paramDMemberBinding, paramEMemberBinding);
		
	var projectionExpression = Expression.Lambda<Func<ClassB, ClassB>>(memberInitExpression, parameterExpressionX);
	var parameterExpressionC = Expression.Parameter(typeClassA, "c");
	var selectParamExpression = Expression.Property(parameterExpressionC, "ClassBs");
	var selectExpression = Expression.Call(
		typeof(Enumerable),
		nameof(Enumerable.Select),
		new[] { typeClassB, typeClassB },
		selectParamExpression, projectionExpression);
	var toListExpression = Expression.Call(
		typeof(Enumerable),
		nameof(Enumerable.ToList),
		new[] { typeClassB },
		selectExpression);

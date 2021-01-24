	var typeClassA = typeof(ClassA);
	var typeClassB = typeof(ClassB);
	
	var parameterExpressionP = Expression.Parameter(typeClassB, "p");
	var newExpression = Expression.New(typeClassB);
	var paramDPropertyExpression = Expression.Property(parameterExpressionP, "ParamD");
	var paramDMemberBinding = Expression.Bind(typeClassB.GetProperty("ParamD"), paramDPropertyExpression);
	var paramEPropertyExpression = Expression.Property(parameterExpressionP, "ParamE");
	var paramEMemberBinding = Expression.Bind(typeClassB.GetProperty("ParamE"), paramEPropertyExpression);
	var memberInitExpression = Expression.MemberInit(
		newExpression,
		paramDMemberBinding, paramEMemberBinding);
		
	var projectionExpression = Expression.Lambda<Func<ClassB, ClassB>>(memberInitExpression, parameterExpressionP);
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

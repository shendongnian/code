	Type t = typeof(T);
	var param1 = Expression.Parameter(t);
	Expression exp = param1;
	foreach (var it in list.Skip(1).Take(list.Count - 2))
	{
		var minfo = t.GetProperty(it).GetGetMethod();
		exp = Expression.Call(exp, minfo);
		t = minfo.ReturnType;
	}
	var lastprop = t.GetProperty(list.Last());
	var minfoset = lastprop.GetSetMethod();
	var variableexp = Expression.Variable(lastprop.PropertyType);
	exp = Expression.Call(exp, minfoset, variableexp);
	var lambda = Expression.Lambda(exp, param1, variableexp);
	lambda.Compile().DynamicInvoke(obj, val);

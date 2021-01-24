	public static Delegate CreateDelegate(this MethodInfo methodInfo, object target, params Type[] custTypes) {
		Func<Type[], Type> getType;
		bool isAction = methodInfo.ReturnType.Equals((typeof(void))), cust = custTypes.Length > 0;
		Type[] types = cust ? custTypes : methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
		if (isAction) getType = Expression.GetActionType;
		else {
			getType = Expression.GetFuncType;
			if (!cust) types = types.Concat(new[] { methodInfo.ReturnType }).ToArray();
		}
		if (cust) {
			int i, nargs = types.Length - (isAction ? 0 : 1);
			var dm = new DynamicMethod(methodInfo.Name, isAction ? typeof(void) : types.Last(), types.Take(nargs).ToArray(), typeof(object), true);
			var il = dm.GetILGenerator();
			for (i = 0; i < nargs; i++)
				il.Emit(OpCodes.Ldarg_S, i);
			il.Emit(OpCodes.Call, methodInfo);
			il.Emit(OpCodes.Ret);
			if (methodInfo.IsStatic) return dm.CreateDelegate(getType(types));
			return dm.CreateDelegate(getType(types), target);
		}
		if (methodInfo.IsStatic) return Delegate.CreateDelegate(getType(types), methodInfo);
		return Delegate.CreateDelegate(getType(types), target, methodInfo.Name);
	}

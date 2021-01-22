    Action myCtor = CreateCtor(t, Type.EmptyTypes, typeof(Action));
    public static Delegate CreateCtor(Type type, Type[] parameterTypes, Type delegateType, string typeParameterName)
	{
		var ctorInfo = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, parameterTypes, null);
		if (ctorInfo == null)
		{
			string parameterString = string.Empty;
			if(parameterTypes.Length > 0)
			{
				string[] parameterStrings = new string[parameterTypes.Length];
				for(int i = 0; i < parameterTypes.Length; ++i)
				{
					parameterStrings[i] = parameterTypes[i].ToString();
				}
				parameterString = string.Join(",", parameterStrings);
			}
			throw new ArgumentException(string.Format("Type '{0}' does not define .ctor({1}).", type, parameterString), typeParameterName);
		}
		bool isVisible = type.IsVisible && (ctorInfo.IsPublic && !ctorInfo.IsFamilyOrAssembly);
		DynamicMethod dynamicCtor = new DynamicMethod(Guid.NewGuid().ToString("N"), type, parameterTypes, ctorInfo.Module, !isVisible);
		var il = dynamicCtor.GetILGenerator();
		for (int i = 0; i < parameterTypes.Length; ++i)
		{
			switch (i)
			{
				case 0: il.Emit(OpCodes.Ldarg_0); break;
				case 1: il.Emit(OpCodes.Ldarg_1); break;
				case 2: il.Emit(OpCodes.Ldarg_2); break;
				case 3: il.Emit(OpCodes.Ldarg_3); break;
				default: il.Emit(OpCodes.Ldarg, i); break;
			}
		}
		il.Emit(OpCodes.Newobj, ctorInfo);
		il.Emit(OpCodes.Ret);
		return dynamicCtor.CreateDelegate(delegateType);
	}

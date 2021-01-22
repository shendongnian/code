    Action<TObject, TField> ConstructGetter(string fieldName)
    {
        System.Reflection.FieldInfo field = typeof(TObject).GetField(fieldName);
        DynamicMethod method = new DynamicMethod(typeof(TObject).ToString() + ":" + "Set:" + name,
												 null, new Type[] { typeof(TObject), typeof(TField) }, typeof(TObject));
		ILGenerator generator = method.GetILGenerator();
		generator.Emit(OpCodes.Ldarg_0);
		generator.Emit(OpCodes.Ldarg_1);
		generator.Emit(OpCodes.Stfld, field);
		generator.Emit(OpCodes.Ret);
		return method.CreateDelegate(typeof(Action<TObject, TField>)) as Action<TObject, TField>;
    }

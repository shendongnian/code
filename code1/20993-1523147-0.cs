    private static Action<object, object> CreateSetAccessor(FieldInfo field)
		{
			DynamicMethod setMethod = new DynamicMethod(field.Name, typeof(void), new[] { typeof(object), typeof(object) });
			ILGenerator generator = setMethod.GetILGenerator();
			LocalBuilder local = generator.DeclareLocal(field.DeclaringType);
			generator.Emit(OpCodes.Ldarg_0);
			if (field.DeclaringType.IsValueType)
			{
				generator.Emit(OpCodes.Unbox_Any, field.DeclaringType);
				generator.Emit(OpCodes.Stloc_0, local);
				generator.Emit(OpCodes.Ldloca_S, local);
			}
			else
			{
				generator.Emit(OpCodes.Castclass, field.DeclaringType);
				generator.Emit(OpCodes.Stloc_0, local);
				generator.Emit(OpCodes.Ldloc_0, local);
			}
			generator.Emit(OpCodes.Ldarg_1);
			if (field.FieldType.IsValueType)
			{
				generator.Emit(OpCodes.Unbox_Any, field.FieldType);
			}
			else
			{
				generator.Emit(OpCodes.Castclass, field.FieldType);
			}
			generator.Emit(OpCodes.Stfld, field);
			generator.Emit(OpCodes.Ret);
			return (Action<object, object>)setMethod.CreateDelegate(typeof(Action<object, object>));
		}

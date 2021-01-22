		private static Build CreateBuilder(Type destinationType, IDataRecord dataRecord)
		{
			var method = new DynamicMethod("DynamicCreate", destinationType, new[] { typeof(IDataRecord) }, destinationType, true);
			var generator = method.GetILGenerator();
			var result = generator.DeclareLocal(destinationType);
			generator.Emit(OpCodes.Newobj, destinationType.GetConstructor(Type.EmptyTypes));
			generator.Emit(OpCodes.Stloc, result);
			for (var i = 0; i < dataRecord.FieldCount; i++)
			{
				var propertyInfo = destinationType.GetProperty(ConvertLowerUnderscoreNamingToPascalNaming(dataRecord.GetName(i)));
				var endIfLabel = generator.DefineLabel();
				if (propertyInfo != null && propertyInfo.GetSetMethod(true) != null)
				{
					generator.Emit(OpCodes.Ldarg_0);
					generator.Emit(OpCodes.Ldc_I4, i);
					generator.Emit(OpCodes.Callvirt, isDBNullMethod);
					generator.Emit(OpCodes.Brtrue, endIfLabel);
					generator.Emit(OpCodes.Ldloc, result);
					generator.Emit(OpCodes.Ldarg_0);
					generator.Emit(OpCodes.Ldc_I4, i);
					generator.Emit(OpCodes.Callvirt, getValueMethod);
					generator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i));
					generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod(true));
					generator.MarkLabel(endIfLabel);
				}
			}
			generator.Emit(OpCodes.Ldloc, result);
			generator.Emit(OpCodes.Ret);
			return (Build)method.CreateDelegate(typeof(Build));
		}
		//TODO: refactor to use INamingConvetion and resolve with RegEx pattern
		private static string ConvertLowerUnderscoreNamingToPascalNaming(string original)
		{
			var LowerOriginal = original.ToLower();
			string[] tokens = LowerOriginal.Split('_');
			string converted = "";
			foreach (var token in tokens)
				converted += token.Substring(0, 1).ToUpper() + token.Substring(1);
			return converted;
		}

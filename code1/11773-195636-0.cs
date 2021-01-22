    var method = new DynamicMethod("Test", null, null);
    var il = method.GetILGenerator();
    
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Newarr, typeof(char));
    il.Emit(OpCodes.Newobj, typeof(string).GetConstructor(new[] { typeof(char[]) }));
    
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Newarr, typeof(char));
    il.Emit(OpCodes.Newobj, typeof(string).GetConstructor(new[] { typeof(char[]) }));
    
    il.Emit(OpCodes.Call, typeof(object).GetMethod("ReferenceEquals"));
    il.Emit(OpCodes.Box, typeof(bool));
    il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(object) }));
    
    il.Emit(OpCodes.Ret);
    
    method.Invoke(null, null);

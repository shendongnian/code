    ilGenerator.Emit(OpCodes.Ldarg_0);  //this
    ilGenerator.Emit(OpCodes.Ldarg_1);  // the first one in arguments list
    
    var toEnd = ilGenerator.DefineLabel();
    ilGenerator.Emit(OpCodes.Beq, toEnd);
    
    ilGenerator.Emit(OpCodes.Ldstr, "Changed");
    ilGenerator.Emit(OpCodes.Call, 
        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
    ilGenerator.Emit(OpCodes.Stfld, fieldBuilder);
    
    ilGenerator.MarkLabel(toEnd);
    ilGenerator.Emit(OpCodes.Ret);

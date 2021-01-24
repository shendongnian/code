    // define assembly and module
    var propertyName = "Name";
    var propertyType = typeof(string);
    var ab = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName("dynamicAssembly"), 
                AssemblyBuilderAccess.Save);
    var mb = ab.DefineDynamicModule("dynamicModule", "dynamicModule.dll");
    // define type, field and property
    var tb = mb.DefineType("dynamicType");
    var fb = tb.DefineField("_name", propertyType, FieldAttributes.Private);
    var pb = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, Type.EmptyTypes);
    var get = tb.DefineMethod("get_" + propertyName,MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
     var set = tb.DefineMethod("set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { propertyType });
    // write the IL for the get method
    var getIl = get.GetILGenerator();
    getIl.Emit(OpCodes.Ldarg_0); // this
    getIl.Emit(OpCodes.Ldfld, fb); // _name field
    getIl.Emit(OpCodes.Ret);
    // write the IL for the set method
    var setIl = set.GetILGenerator();
    Label exitSet = setIl.DefineLabel(); // define label to jump in case condition is false
    setIl.Emit(OpCodes.Ldarg_0); // this
    setIl.Emit(OpCodes.Ldfld, fb); // _name field
    setIl.Emit(OpCodes.Ldarg_1); // value
    var inequality = propertyType.GetMethod("op_Inequality", new[] { propertyType, propertyType });
    setIl.Emit(OpCodes.Call, inequality); // '!=' method
    setIl.Emit(OpCodes.Brfalse_S, exitSet); // check for inequality
    setIl.Emit(OpCodes.Ldstr, "changedto:"); // load string literal
    setIl.Emit(OpCodes.Ldarg_1); // value
    var concat = propertyType.GetMethod("Concat", new[] { propertyType, propertyType });
    setIl.Emit(OpCodes.Call, concat); // concat two strings (literal + value)
    var writeline = typeof(Console).GetMethod("WriteLine", new[] { propertyType });
    setIl.Emit(OpCodes.Call, writeline); // write
    setIl.Emit(OpCodes.Ldarg_0); // this
    setIl.Emit(OpCodes.Ldarg_1); // value
    setIl.Emit(OpCodes.Stfld, fb); // save the new value into _name
    setIl.MarkLabel(exitSet); // mark the label
    setIl.Emit(OpCodes.Ret); // return
    pb.SetGetMethod(get);
    pb.SetSetMethod(set);
    tb.CreateType(); // complete the type
    ab.Save("dynamicModule.dll"); // save the assembly to disk

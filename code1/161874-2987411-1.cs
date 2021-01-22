    var dm = new System.Reflection.Emit.DynamicMethod("My_method",
        typeof(string), null);
    var il = dm.GetILGenerator();
    il.Emit(OpCodes.Ldstr, "Hello, world!");
    il.Emit(OpCodes.Ret);
    Func<string> func = (Func<string>)dm.CreateDelegate(typeof(Func<string>));
    var s = func();

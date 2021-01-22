    public void Test()
    {
        DynamicMethod method = new DynamicMethod(string.Empty, typeof(void), new[] { typeof(object), typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32) }, typeof(Program));
        MethodInfo method1 = typeof(Program).GetMethod("Question", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32) }, null);
        MethodInfo method2 = typeof(MethodBase).GetMethod("GetCurrentMethod", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { }, null);
        MethodInfo method3 = typeof(Console).GetMethod("WriteLine", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Object) }, null);
        ILGenerator gen = method.GetILGenerator();
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Ldarg_S, 0);
        gen.Emit(OpCodes.Ldarg_S, 1);
        gen.Emit(OpCodes.Ldarg_S, 2);
        gen.Emit(OpCodes.Ldarg_S, 3);
        gen.Emit(OpCodes.Ldarg_S, 4);
        gen.Emit(OpCodes.Ldarg_S, 5);
        gen.Emit(OpCodes.Ldarg_S, 6);
        gen.Emit(OpCodes.Call, method1);
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Call, method2);
        gen.Emit(OpCodes.Call, method3);
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Ret);
        TestHandler handler = method.CreateDelegate(typeof(TestHandler)) as TestHandler;
        handler(this, 1, 2, 3, 4, 5, 6);
    }
    public void Question(int a, int b, int c, int d, int e, int f)
    {
        Console.WriteLine("{0},{1},{2},{3},{4},{5}", a, b, c, d, e, f);
    }

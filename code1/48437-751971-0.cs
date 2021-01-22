    delegate string SayNoDelegate(BaseClass instance);
    static void Main() {
        BaseClass target = new SecondClass();
        var method_args = new Type[] { typeof(BaseClass) };
        var pull = new DynamicMethod("pull", typeof(string), method_args);
        var method = typeof(BaseClass).GetMethod("SayNo", new Type[] {});
        var ilgen = pull.GetILGenerator();
        ilgen.Emit(OpCodes.Ldarg_0);
        ilgen.EmitCall(OpCodes.Call, method, null);
        ilgen.Emit(OpCodes.Ret);
        var call = (SayNoDelegate)pull.CreateDelegate(typeof(SayNoDelegate));
        Console.WriteLine("callvirt, in C#: {0}", target.SayNo());
        Console.WriteLine("call, in IL: {0}", call(target));
    }

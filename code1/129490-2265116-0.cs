    class Program
    {
        static void Main(string[] args)
        {
            var aName = new AssemblyName("DynamicAssemblyExample");
            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            var mb = ab.DefineDynamicModule(aName.Name);
            var tb = mb.DefineType("MyDynamicType", TypeAttributes.Public);
            var fbId = tb.DefineField("_id", typeof(int), FieldAttributes.Private);
            var pbId = tb.DefineProperty("Id", PropertyAttributes.HasDefault, typeof(int), null);
    
            var getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual;
    
            var mbIdGetAccessor = tb.DefineMethod("get_Id", getSetAttr, typeof(int), Type.EmptyTypes);
    
            var numberGetIL = mbIdGetAccessor.GetILGenerator();
            numberGetIL.Emit(OpCodes.Ldarg_0);
            numberGetIL.Emit(OpCodes.Ldfld, fbId);
            numberGetIL.Emit(OpCodes.Ret);
    
            var mbIdSetAccessor = tb.DefineMethod("set_Id", getSetAttr, null, new Type[] { typeof(int) });
    
            var numberSetIL = mbIdSetAccessor.GetILGenerator();
            numberSetIL.Emit(OpCodes.Ldarg_0);
            numberSetIL.Emit(OpCodes.Ldarg_1);
            numberSetIL.Emit(OpCodes.Stfld, fbId);
            numberSetIL.Emit(OpCodes.Ret);
    
            pbId.SetGetMethod(mbIdGetAccessor);
            pbId.SetSetMethod(mbIdSetAccessor);
    
            var t = tb.CreateType();
            var instance = Activator.CreateInstance(t);
            Console.WriteLine(t.GetProperty("Id").GetGetMethod().IsVirtual);
        }
    }

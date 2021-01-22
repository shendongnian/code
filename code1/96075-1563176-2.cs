    public MethodBuilder BuildMethodPrecompiledTest(TypeBuilder type)
    {
        // Declaring method builder
        // Method attributes
        System.Reflection.MethodAttributes methodAttributes = 
              System.Reflection.MethodAttributes.Private
            | System.Reflection.MethodAttributes.HideBySig
            | System.Reflection.MethodAttributes.Static;
        MethodBuilder method = type.DefineMethod("PrecompiledTest", methodAttributes);
        // Preparing Reflection instances
        ConstructorInfo ctor1 = typeof(TestClass).GetConstructor(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
            null, 
            new Type[]{
                }, 
            null
            );
        MethodInfo method2 = typeof(TestClass).GetMethod(
            "TestMethod", 
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
            null, 
            new Type[]{
                }, 
            null
            );
        // Setting return type
        method.SetReturnType(typeof(Object));
        // Adding parameters
        ILGenerator gen =  method.GetILGenerator();
        // Preparing locals
        LocalBuilder variable =  gen.DeclareLocal(typeof(Object));
        LocalBuilder CS$1$0000 =  gen.DeclareLocal(typeof(Object));
        // Preparing labels
        Label label23 =  gen.DefineLabel();
        // Writing body
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Newobj,ctor1);
        gen.Emit(OpCodes.Stloc_0);
        gen.Emit(OpCodes.Ldloc_0);
        gen.Emit(OpCodes.Castclass,TestClass);
        gen.Emit(OpCodes.Callvirt,method2);
        gen.Emit(OpCodes.Nop);
        gen.Emit(OpCodes.Ldloc_0);
        gen.Emit(OpCodes.Stloc_1);
        gen.Emit(OpCodes.Br_S,label23);
        gen.MarkLabel(label23);
        gen.Emit(OpCodes.Ldloc_1);
        gen.Emit(OpCodes.Ret);
        // finished
        return method;
    }

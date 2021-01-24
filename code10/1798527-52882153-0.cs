            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Test"), AssemblyBuilderAccess.Save);
            TypeBuilder typeBuilder = assemblyBuilder
                .DefineDynamicModule("Module", "Test.exe", false)
                .DefineType("Program", TypeAttributes.Public);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main2", MethodAttributes.Public | MethodAttributes.Static);
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.EmitWriteLine("Main2");
            ilGenerator.Emit(OpCodes.Ret);
            assemblyBuilder.SetEntryPoint(methodBuilder);
            typeBuilder.CreateType();
            assemblyBuilder.Save("Test.exe");

            MethodInfo writeLine = typeof(Console).GetMethod("WriteLine", new Type[] {typeof(string)});
            RuntimeMethodHandle myMethodHandle = writeLine.MethodHandle;
            DynamicMethod dm = new DynamicMethod(
                "HelloWorld",          // name of the method
                typeof(void),          // return type of the method
                new Type[] { },          // argument types for the method
                false);                // skip JIT visibility checks
            ILGenerator il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "Hello, world");
            il.EmitCall(OpCodes.Call, writeLine, null);
            il.Emit(OpCodes.Ret);
            // test it 
            Action act = (Action)dm.CreateDelegate(typeof(Action));
            act();

            // Build the method body for the explicit interface 
            // implementation. The name used for the method body 
            // can be anything. Here, it is the name of the method,
            // qualified by the interface name.
            //
            MethodBuilder mbIM = tb.DefineMethod("I.M", 
                MethodAttributes.Private | MethodAttributes.HideBySig |
                    MethodAttributes.NewSlot | MethodAttributes.Virtual | 
                    MethodAttributes.Final,
                null,
                Type.EmptyTypes);
            ILGenerator il = mbIM.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "The I.M implementation of C");
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", 
                new Type[] { typeof(string) }));
            il.Emit(OpCodes.Ret);
    
            // DefineMethodOverride is used to associate the method 
            // body with the interface method that is being implemented.
            //
            tb.DefineMethodOverride(mbIM, typeof(I).GetMethod("M"));

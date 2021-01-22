    internal delegate object FastConstructorHandler(object[] paramters);
    
        private static FastConstructorHandler CreateDelegate(Type Tipo)
        {
            DynamicMethod dynamicMethod = new DynamicMethod(string.Empty,
                typeof(object), new Type[] { typeof(object[]) }, Tipo.Module, false);
    
            ILGenerator ilg = dynamicMethod.GetILGenerator();
    
            ilg.DeclareLocal(Tipo);
            ilg.Emit(OpCodes.Ldloca_S, (byte)0);
            ilg.Emit(OpCodes.Initobj, Tipo);
            ilg.Emit(OpCodes.Ldloc_0);
            ilg.Emit(OpCodes.Box, Tipo);
            ilg.Emit(OpCodes.Ret);
    
            return (FastConstructorHandler)dynamicMethod.CreateDelegate(typeof(FastConstructorHandler));
        }

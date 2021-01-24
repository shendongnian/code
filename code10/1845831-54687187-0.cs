            Label exitSet = setIl.DefineLabel();
            MethodInfo op_inequality = propertyType.GetMethod("op_Inequality", new Type[] { propertyType, propertyType });
            if (op_inequality != null)
            {
                setIl.Emit(OpCodes.Ldarg_0);
                setIl.Emit(OpCodes.Ldfld, fb);
                setIl.Emit(OpCodes.Ldarg_1);
                setIl.Emit(OpCodes.Call, op_inequality);
                setIl.Emit(OpCodes.Brfalse_S, exitSet);
            }
            else
            {
                // Use object inequality
                setIl.Emit(OpCodes.Ldarg_0);
                setIl.Emit(OpCodes.Ldfld, fb);
                if (propertyType.IsValueType)
                {
                    setIl.Emit(OpCodes.Box, propertyType);
                }
                setIl.Emit(OpCodes.Ldarg_1);
                if (propertyType.IsValueType)
                {
                    setIl.Emit(OpCodes.Box, propertyType);
                }
                setIl.Emit(OpCodes.Call, EqualsMethod);
                setIl.Emit(OpCodes.Brtrue_S, exitSet);
            }
            
            setIl.Emit(OpCodes.Ldarg_0); // load string literal
            setIl.Emit(OpCodes.Ldarg_1); // value
            //-----------------important---------
            if (propertyType.IsValueType)
            {
                setIl.Emit(OpCodes.Box, propertyType);
            }
            setIl.Emit(OpCodes.Ldstr, property.Name);
            var parentType = tb.BaseType;
            //if (parentType == null)
            //    throw new Exception($"Interface {tb.Name} should be inherited from \"IDbEntity\". ");
            var m = parentType.GetMethod("ValueChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            setIl.Emit(OpCodes.Call, m);

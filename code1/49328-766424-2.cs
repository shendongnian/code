    class Util
    {
        public static Func<T,T, List<string>> CreateDitryChecker<T>()
        {
            var dm = 
                new DynamicMethod
                (
                    "$dirty_checker", 
                    typeof(List<string>), 
                    new[] { typeof(T), typeof(T) }, 
                    typeof(T)
                );
            var ilGen = dm.GetILGenerator();
            //var retVar = new List<string>();
            var retVar = ilGen.DeclareLocal(typeof(List<string>));
            ilGen.Emit(OpCodes.Newobj, typeof(List<string>).GetConstructor(new Type[0]));
            ilGen.Emit(OpCodes.Stloc, retVar);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo objEqualsMehtod = typeof(object).GetMethod("Equals", new[] { typeof(object) });
            MethodInfo listAddMethod = typeof(List<string>).GetMethod("Add");
            foreach (PropertyInfo prop in properties)
            {
                //Inject code equivalent to the following into the method:
                //if (arg1.prop == null)
                //{
                //     if (arg2.prop != null)
                //     {
                //         retVar.Add("prop")
                //     }
                //}
                //else
                //{
                //    if (! arg1.prop.Equals(arg2))
                //    {
                //        retVar.Add("prop")    
                //    }
                //}
                Label endLabel = ilGen.DefineLabel();
                Label elseLabel = ilGen.DefineLabel();
                
                //if arg1.prop != null, goto elseLabel
                ilGen.Emit(OpCodes.Ldarg_0);
                ilGen.Emit(OpCodes.Call, prop.GetGetMethod());
                ilGen.Emit(OpCodes.Brtrue, elseLabel);
                //if arg2.prop != null, goto endLabel
                ilGen.Emit(OpCodes.Ldarg_1);
                ilGen.EmitCall(OpCodes.Call, prop.GetGetMethod(), null);
                ilGen.Emit(OpCodes.Brfalse, endLabel);
                //retVar.Add("prop");
                ilGen.Emit(OpCodes.Ldloc, retVar);
                ilGen.Emit(OpCodes.Ldstr, prop.Name);
                ilGen.EmitCall(OpCodes.Callvirt, listAddMethod, null);
                ilGen.Emit(OpCodes.Br, endLabel);
                //elseLabel:
                ilGen.MarkLabel(elseLabel);
                //if (arg0.prop.Equals(arg1.prop), goto endLabel
                ilGen.Emit(OpCodes.Ldarg_0);
                ilGen.EmitCall(OpCodes.Call, prop.GetGetMethod(), null);
                ilGen.Emit(OpCodes.Ldarg_1);
                ilGen.EmitCall(OpCodes.Call, prop.GetGetMethod(), null);
                ilGen.EmitCall(OpCodes.Callvirt, objEqualsMehtod, null);
                ilGen.Emit(OpCodes.Brtrue, endLabel);
                //retVar.Add("prop")
                ilGen.Emit(OpCodes.Ldloc, retVar);
                ilGen.Emit(OpCodes.Ldstr, prop.Name);
                ilGen.EmitCall(OpCodes.Callvirt, listAddMethod, null);
                
                //endLAbel:
                ilGen.MarkLabel(endLabel);
            }
            ilGen.Emit(OpCodes.Ldloc, retVar);
            ilGen.Emit(OpCodes.Ret);
            return (Func<T, T, List<string>>) dm.CreateDelegate(typeof(Func<T, T, List<string>>));
        }
    }

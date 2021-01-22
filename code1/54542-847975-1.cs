    public static class GroupGenerator
    {
        public static T Create<T>(IEnumerable<T> items)
        {
            return (T) Activator.CreateInstance(Cache<T>.Type, items);
        }
        public static class Cache<T>
        {
            public static readonly Type Type;
            static Cache()
            {
                AssemblyName an = new AssemblyName("tmp_" + typeof(T).Name);
                var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);
                var module = asm.DefineDynamicModule(an.Name, false);
                var type = module.DefineType("grp_" + typeof(T).Name,
                    TypeAttributes.Class | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.NotPublic);
                type.AddInterfaceImplementation(typeof(T));
                var fld = type.DefineField("items", typeof(IEnumerable<T>), FieldAttributes.Private);
                var ctor = type.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis,
                    new Type[] { fld.FieldType });
                var il = ctor.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Stfld, fld);
                il.Emit(OpCodes.Ret);
                foreach (var method in typeof(T).GetMethods())
                {
                    var methodImpl = type.DefineMethod(method.Name, MethodAttributes.Private | MethodAttributes.Virtual,
                        method.ReturnType, method.GetParameters().Select(x=>x.ParameterType).ToArray());
                    il = methodImpl.GetILGenerator();
                    var iter = il.DeclareLocal(typeof(IEnumerator<T>));
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, fld);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerable<T>).GetMethod("GetEnumerator"), null);
                    il.Emit(OpCodes.Stloc, iter);
                    
                    Label loop = il.DefineLabel();
                    il.Emit(OpCodes.Br_S, loop);
                    Label doItem = il.DefineLabel();
                    il.MarkLabel(doItem);
                    il.Emit(OpCodes.Ldloc, iter);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerator<T>).GetProperty("Current").GetGetMethod(), null);
                    var args = method.GetParameters();
                    for (int i = 0; i < args.Length; i++)
                    {
                        switch (i)
                        {
                            case 0: il.Emit(OpCodes.Ldarg_1); break;
                            case 1: il.Emit(OpCodes.Ldarg_2); break;
                            case 2: il.Emit(OpCodes.Ldarg_3); break;
                            default:
                                il.Emit(i < 255 ? OpCodes.Ldarg_S : OpCodes.Ldarg, i + 1);
                                break;
                        }
                    }
                    il.EmitCall(OpCodes.Callvirt, method, null);
                    il.MarkLabel(loop);
                    il.Emit(OpCodes.Ldloc, iter);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerator).GetMethod("MoveNext"), null);
                    il.Emit(OpCodes.Brtrue_S, doItem);
                    il.Emit(OpCodes.Ldloc, iter);
                    il.EmitCall(OpCodes.Callvirt, typeof(IDisposable).GetMethod("Dispose"), null);
                    il.Emit(OpCodes.Ret);
                    type.DefineMethodOverride(methodImpl, method);
                }
                Cache<T>.Type = type.CreateType();
            }
    
            public static void ForEach(IEnumerable<T> items, Action<T> action)
            {
                foreach (var item in items) action(item);
            }
        }
    }

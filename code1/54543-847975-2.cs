    public static class GroupGenerator
    {
        public static T Create<T>(IEnumerable<T> items) where T : class
        {
            return (T)Activator.CreateInstance(Cache<T>.Type, items);
        }
        private static class Cache<T> where T : class
        {
            internal static readonly Type Type;
            static Cache()
            {
                if (!typeof(T).IsInterface)
                {
                    throw new InvalidOperationException(typeof(T).Name
                        + " is not an interface");
                }
                AssemblyName an = new AssemblyName("tmp_" + typeof(T).Name);
                var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    an, AssemblyBuilderAccess.RunAndSave);
                string moduleName = Path.ChangeExtension(an.Name,"dll");
                var module = asm.DefineDynamicModule(moduleName, false);
                string ns = typeof(T).Namespace;
                if (!string.IsNullOrEmpty(ns)) ns += ".";
                var type = module.DefineType(ns + "grp_" + typeof(T).Name,
                    TypeAttributes.Class | TypeAttributes.AnsiClass |
                    TypeAttributes.Sealed | TypeAttributes.NotPublic);
                type.AddInterfaceImplementation(typeof(T));
    
                var fld = type.DefineField("items", typeof(IEnumerable<T>),
                    FieldAttributes.Private);
                var ctor = type.DefineConstructor(MethodAttributes.Public,
                    CallingConventions.HasThis, new Type[] { fld.FieldType });
                var il = ctor.GetILGenerator();
                // store the items
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Stfld, fld);
                il.Emit(OpCodes.Ret);
    
                foreach (var method in typeof(T).GetMethods())
                {
                    var args = method.GetParameters();
                    var methodImpl = type.DefineMethod(method.Name,
                        MethodAttributes.Private | MethodAttributes.Virtual,
                        method.ReturnType,
                        Array.ConvertAll(args, arg => arg.ParameterType));
                    type.DefineMethodOverride(methodImpl, method);
                    il = methodImpl.GetILGenerator();
                    if (method.ReturnType != typeof(void))
                    {
                        il.Emit(OpCodes.Ldstr,
                            "Methods with return values are not supported");
                        il.Emit(OpCodes.Newobj, typeof(NotSupportedException)
                            .GetConstructor(new Type[] {typeof(string)}));
                        il.Emit(OpCodes.Throw);
                        continue;
                    }
                    
                    // get the iterator
                    var iter = il.DeclareLocal(typeof(IEnumerator<T>));
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, fld);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerable<T>)
                        .GetMethod("GetEnumerator"), null);
                    il.Emit(OpCodes.Stloc, iter);
                    Label tryFinally = il.BeginExceptionBlock();
    
                    // jump to "progress the iterator"
                    Label loop = il.DefineLabel();
                    il.Emit(OpCodes.Br_S, loop);
                    
                    // process each item (invoke the paired method)
                    Label doItem = il.DefineLabel();
                    il.MarkLabel(doItem);
                    il.Emit(OpCodes.Ldloc, iter);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerator<T>)
                        .GetProperty("Current").GetGetMethod(), null);
                    for (int i = 0; i < args.Length; i++)
                    { // load the arguments
                        switch (i)
                        {
                            case 0: il.Emit(OpCodes.Ldarg_1); break;
                            case 1: il.Emit(OpCodes.Ldarg_2); break;
                            case 2: il.Emit(OpCodes.Ldarg_3); break;
                            default:
                                il.Emit(i < 255 ? OpCodes.Ldarg_S
                                    : OpCodes.Ldarg, i + 1);
                                break;
                        }
                    }
                    il.EmitCall(OpCodes.Callvirt, method, null);
    
                    // progress the iterator
                    il.MarkLabel(loop);
                    il.Emit(OpCodes.Ldloc, iter);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerator)
                        .GetMethod("MoveNext"), null);
                    il.Emit(OpCodes.Brtrue_S, doItem);
                    il.Emit(OpCodes.Leave_S, tryFinally);
    
                    // dispose iterator
                    il.BeginFinallyBlock();
                    Label endFinally = il.DefineLabel();
                    il.Emit(OpCodes.Ldloc, iter);
                    il.Emit(OpCodes.Brfalse_S, endFinally);
                    il.Emit(OpCodes.Ldloc, iter);
                    il.EmitCall(OpCodes.Callvirt, typeof(IDisposable)
                        .GetMethod("Dispose"), null);
                    il.MarkLabel(endFinally);
                    il.EndExceptionBlock();
                    il.Emit(OpCodes.Ret);
                }
                Cache<T>.Type = type.CreateType();
    #if DEBUG       // for inspection purposes...
                asm.Save(moduleName);
    #endif
            }
        }
    }

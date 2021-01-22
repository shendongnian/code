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
                    var methodImpl = type.DefineMethod(method.Name, MethodAttributes.Private | MethodAttributes.Virtual);
                    il = methodImpl.GetILGenerator();
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, fld);
                    il.Emit(OpCodes.Ldnull);
                    il.Emit(OpCodes.Ldftn, method);
                    il.Emit(OpCodes.Newobj, typeof(Action<T>).GetConstructor(new Type[] { typeof(object), typeof(IntPtr) }));
                    il.EmitCall(OpCodes.Call, typeof(Cache<T>).GetMethod("ForEach"), null);
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

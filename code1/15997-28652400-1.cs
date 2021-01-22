    public class MixinGenerator
    {
        public static Type CreateMixin(Type @base, Type mixin)
        {
            // Mixin must be an interface
            if (!mixin.IsInterface)
                throw new ArgumentException("mixin not an interface");
                        
            TypeBuilder typeBuilder = DefineType(@base, new Type[]{mixin});
            FieldBuilder fb = typeBuilder.DefineField("impl", mixin, FieldAttributes.Private);
            DefineConstructor(typeBuilder, fb);
            DefineInterfaceMethods(typeBuilder, mixin, fb);
            Type t = typeBuilder.CreateType();
            return t;
        }
        static AssemblyBuilder assemblyBuilder;
        private static TypeBuilder DefineType(Type @base, Type [] interfaces)
        {
            assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(Guid.NewGuid().ToString());
            TypeBuilder b = moduleBuilder.DefineType(Guid.NewGuid().ToString(),
                @base.Attributes,
                @base,
                interfaces);
            return b;
        }
        private static void DefineConstructor(TypeBuilder typeBuilder, FieldBuilder fieldBuilder)
        {
            ConstructorBuilder ctor = typeBuilder.DefineConstructor(
                MethodAttributes.Public, CallingConventions.Standard, new Type[] { fieldBuilder.FieldType });
            ILGenerator il = ctor.GetILGenerator();
            // Call base constructor
            ConstructorInfo baseCtorInfo =  typeBuilder.BaseType.GetConstructor(new Type[]{});
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, typeBuilder.BaseType.GetConstructor(new Type[0]));
            // Store type parameter in private field
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, fieldBuilder);
            il.Emit(OpCodes.Ret);
        }
        private static void DefineInterfaceMethods(TypeBuilder typeBuilder, Type mixin, FieldInfo instanceField)
        {
            MethodInfo[] methods = mixin.GetMethods();
            foreach (MethodInfo method in methods)
            {
                MethodInfo fwdMethod = instanceField.FieldType.GetMethod(method.Name,
                    method.GetParameters().Select((pi) => { return pi.ParameterType; }).ToArray<Type>());
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                                                fwdMethod.Name,
                                                // Could not call absract method, so remove flag
                                                fwdMethod.Attributes & (~MethodAttributes.Abstract),
                                                fwdMethod.ReturnType,
                                                fwdMethod.GetParameters().Select(p => p.ParameterType).ToArray());
                methodBuilder.SetReturnType(method.ReturnType);
                typeBuilder.DefineMethodOverride(methodBuilder, method);
                
                // Emit method body
                ILGenerator il = methodBuilder.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, instanceField);
                // Call with same parameters
                for (int i = 0; i < method.GetParameters().Length; i++)
                {
                    il.Emit(OpCodes.Ldarg, i + 1);
                }
                il.Emit(OpCodes.Call, fwdMethod);
                il.Emit(OpCodes.Ret);
            }
        }
    }

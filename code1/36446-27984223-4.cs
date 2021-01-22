    public class ServiceHelper<T>
    {
        private readonly ChannelFactory<T> _channelFactory;
        private static readonly Func<T, IDisposable, T> _channelCreator;
        static ServiceHelper()
        {
            /** 
             * Create a method that can be used generate the channel. 
             * This is effectively a compiled verion of new ProxyWrappper(channel, channelDisposer) for our proxy type
             * */
            var assemblyName = Guid.NewGuid().ToString();
            var an = new AssemblyName(assemblyName);
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName);
            var proxyType = CreateProxyType(moduleBuilder, typeof(T), typeof(IDisposable));
            var channelCreatorMethod = new DynamicMethod("ChannelFactory", typeof(T),
                new[] { typeof(T), typeof(IDisposable) });
            var ilGen = channelCreatorMethod.GetILGenerator();
            var proxyVariable = ilGen.DeclareLocal(typeof(T));
            var disposableVariable = ilGen.DeclareLocal(typeof(IDisposable));
            ilGen.Emit(OpCodes.Ldarg, proxyVariable);
            ilGen.Emit(OpCodes.Ldarg, disposableVariable);
            ilGen.Emit(OpCodes.Newobj, proxyType.GetConstructor(new[] { typeof(T), typeof(IDisposable) }));
            ilGen.Emit(OpCodes.Ret);
            _channelCreator =
                (Func<T, IDisposable, T>)channelCreatorMethod.CreateDelegate(typeof(Func<T, IDisposable, T>));
        }
        public ServiceHelper(ChannelFactory<T> channelFactory)
        {
            _channelFactory = channelFactory;
        }
        public T CreateChannel()
        {
            var channel = _channelFactory.CreateChannel();
            var channelDisposer = new ProxyDisposer(channel as IClientChannel);
            return _channelCreator(channel, channelDisposer);
        }
       /**
        * Creates a dynamic type analogous to ProxyWrapper, implementing T and IDisposable.
        * This method is actually more generic than this exact scenario.
        * */
        private static Type CreateProxyType(ModuleBuilder moduleBuilder, params Type[] interfacesToInjectAndImplement)
        {
            TypeBuilder tb = moduleBuilder.DefineType(Guid.NewGuid().ToString(),
                TypeAttributes.Public | TypeAttributes.Class);
            var typeFields = interfacesToInjectAndImplement.ToDictionary(tf => tf,
                tf => tb.DefineField("_" + tf.Name, tf, FieldAttributes.Private));
            #region Constructor
            var constructorBuilder = tb.DefineConstructor(
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                MethodAttributes.RTSpecialName,
                CallingConventions.Standard,
                interfacesToInjectAndImplement);
            var il = constructorBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            for (var i = 1; i <= interfacesToInjectAndImplement.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg, i);
                il.Emit(OpCodes.Stfld, typeFields[interfacesToInjectAndImplement[i - 1]]);
            }
            il.Emit(OpCodes.Ret);
            #endregion
            #region Add Interface Implementations
            foreach (var type in interfacesToInjectAndImplement)
            {
                tb.AddInterfaceImplementation(type);
            }
            #endregion
            #region Implement Interfaces
            foreach (var type in interfacesToInjectAndImplement)
            {
                foreach (var method in type.GetMethods())
                {
                    var methodBuilder = tb.DefineMethod(method.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig |
                        MethodAttributes.Final | MethodAttributes.NewSlot,
                        method.ReturnType,
                        method.GetParameters().Select(p => p.ParameterType).ToArray());
                    il = methodBuilder.GetILGenerator();
                    if (method.ReturnType == typeof(void))
                    {
                        il.Emit(OpCodes.Nop);
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, typeFields[type]);
                        il.Emit(OpCodes.Callvirt, method);
                        il.Emit(OpCodes.Ret);
                    }
                    else
                    {
                        il.DeclareLocal(method.ReturnType);
                        il.Emit(OpCodes.Nop);
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, typeFields[type]);
                        var methodParameterInfos = method.GetParameters();
                        for (var i = 0; i < methodParameterInfos.Length; i++)
                            il.Emit(OpCodes.Ldarg, (i + 1));
                        il.Emit(OpCodes.Callvirt, method);
                        il.Emit(OpCodes.Stloc_0);
                        var defineLabel = il.DefineLabel();
                        il.Emit(OpCodes.Br_S, defineLabel);
                        il.MarkLabel(defineLabel);
                        il.Emit(OpCodes.Ldloc_0);
                        il.Emit(OpCodes.Ret);
                    }
                    tb.DefineMethodOverride(methodBuilder, method);
                }
            }
            #endregion
            return tb.CreateType();
        }
    }

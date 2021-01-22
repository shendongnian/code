    public class Dynamic
    {
        public Dynamic Add<T>(string key, T value)
        {
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Dynamic.dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType(Guid.NewGuid().ToString());
            typeBuilder.SetParent(this.GetType());
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(key, PropertyAttributes.None, typeof(T), Type.EmptyTypes);
            
            MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("get_" + key, MethodAttributes.Public, CallingConventions.HasThis, typeof(T), Type.EmptyTypes);
            ILGenerator getter = getMethodBuilder.GetILGenerator();
            getter.Emit(OpCodes.Ldarg_0);
            getter.Emit(OpCodes.Ldstr, key);
            getter.Emit(OpCodes.Callvirt, typeof(Dynamic).GetMethod("Get", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(typeof(T)));
            getter.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(getMethodBuilder);
    
            Type type = typeBuilder.CreateType();
    
            Dynamic child = (Dynamic)Activator.CreateInstance(type);
            child.dictionary = this.dictionary;
            dictionary.Add(key, value);
            return child;
        }
    
        protected T Get<T>(string key)
        {
            return (T)dictionary[key];
        }
    
        private Dictionary<string, object> dictionary = new Dictionary<string,object>();
    }

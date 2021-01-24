    static class Extensions {
        private static ModuleBuilder _moduleBuilder;
        private static readonly Dictionary<Type, Type> _proxies = new Dictionary<Type, Type>();
        static Type GetProxyType<T>() {
            lock (typeof(Extensions)) {
                if (_proxies.ContainsKey(typeof(T)))
                    return _proxies[typeof(T)];
                if (_moduleBuilder == null) {
                    var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                        new AssemblyName("ExcludeProxies"), AssemblyBuilderAccess.Run);
                    _moduleBuilder = asmBuilder.DefineDynamicModule(
                        asmBuilder.GetName().Name, false);
                }
                // Create a proxy type
                TypeBuilder typeBuilder = _moduleBuilder.DefineType(typeof(T).Name + "Proxy",
                    TypeAttributes.Public |
                    TypeAttributes.Class,
                    typeof(T));
                var type = typeBuilder.CreateType();
                // cache it
                _proxies.Add(typeof(T), type);
                return type;
            }
        }
        public static IQueryable<T> IncludeOnly<T>(this IQueryable<T> query, params string[] properties) {
            var arg = Expression.Parameter(typeof(T), "x");
            var bindings = new List<MemberBinding>();
            foreach (var propName in properties) {
                var prop = typeof(T).GetProperty(propName);
                bindings.Add(Expression.Bind(prop, Expression.Property(arg, prop)));
            }
            // modified select, (T x) => new TProxy {Prop1 = x.Prop1, Prop2 = x.Prop2 ...}
            var select = Expression.Lambda<Func<T, T>>(Expression.MemberInit(Expression.New(GetProxyType<T>()), bindings), arg);
            return query.Select(select);
        }
    }

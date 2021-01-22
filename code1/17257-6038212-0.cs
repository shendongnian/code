        private static readonly Dictionary<Type, MethodInfo> Parsers = new Dictionary<Type, MethodInfo>();
        public static T Parse<T>(this string value, T defaultValue = default(T))
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            if (!Parsers.ContainsKey(typeof(T)))
                Parsers[typeof (T)] = typeof (T).GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(mi => mi.Name == "TryParse")
                    .Single(mi =>
                                {
                                    var parameters = mi.GetParameters();
                                    if (parameters.Length != 2) return false;
                                    return parameters[0].ParameterType == typeof (string) &&
                                           parameters[1].ParameterType == typeof (T).MakeByRefType();
                                });
            var @params = new object[] {value, default(T)};
            return (bool) Parsers[typeof (T)].Invoke(null, @params) ? 
                (T) @params[1] : defaultValue;
        }

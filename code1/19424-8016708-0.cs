        public static IEnumerable<KeyValuePair<Type, MethodInfo>> GetExtensionMethodsDefinedInType(this Type t)
        {
            if (!t.IsSealed || t.IsGenericType || t.IsNested)
                return Enumerable.Empty<KeyValuePair<Type, MethodInfo>>();
            var methods = t.GetMethods(BindingFlags.Public | BindingFlags.Static)
                           .Where(m => m.IsDefined(typeof(ExtensionAttribute), false));
            List<KeyValuePair<Type, MethodInfo>> pairs = new List<KeyValuePair<Type, MethodInfo>>();
            foreach (var m in methods)
            {
                var parameters = m.GetParameters();
                if (parameters.Length > 0)
                {
                    if (parameters[0].ParameterType.IsGenericParameter)
                    {
                        if (m.ContainsGenericParameters)
                        {
                            var genericParameters = m.GetGenericArguments();
                            Type genericParam = genericParameters[parameters[0].ParameterType.GenericParameterPosition];
                            foreach (var constraint in genericParam.GetGenericParameterConstraints())
                                pairs.Add(new KeyValuePair<Type, MethodInfo>(parameters[0].ParameterType, m));
                        }
                    }
                    else
                        pairs.Add(new KeyValuePair<Type, MethodInfo>(parameters[0].ParameterType, m));
                }
            }
            return pairs;
        }

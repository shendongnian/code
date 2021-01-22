        public static bool HasAttributeOfType<T>(this ICustomAttributeProvider provider)
        {
            return provider.GetCustomAttributes(typeof(T), false).Length > 0;
        }
        public static IEnumerable<Type> ThisTypeAndSubClasses(this Type startingType)
        {
            var types = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (startingType.IsAssignableFrom(type))
                        {
                            types.Add(type);
                        }
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    // Some assembly types are unable to be loaded when running as nunit tests.
                    // Move on to the next assembly
                }
            }
            return types;
        }

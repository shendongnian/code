        public static IEnumerable<Type> GetTypesWith<TAttribute>(bool inherit) where TAttribute : Attribute
        {
            var output = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assembly_types = assembly.GetTypes();
                foreach (var type in assembly_types)
                {
                    if (type.IsDefined(typeof(TAttribute), inherit))
                        output.Add(type);
                }
            }
            return output;
        }

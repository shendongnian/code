        public IEnumerable<Type> GetTypesWith<TAttribute>(bool inherit) where TAttribute : Attribute
        {
            var output = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Type type = assembly.GetType();
                if (type.IsDefined(typeof(TAttribute), inherit))
                    output.Add(type);
            }
            return output;
        }

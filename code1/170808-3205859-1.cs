        private void BuildComponents(ContainerBuilder builder)
        {
            string currentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!Path.GetDirectoryName(assembly.Location).Equals(currentDirectory))
                    continue;
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => t.IsComponent())
                    .AsImplementedInterfaces()
                    .SingleInstance();
            }
        }
        public static bool IsComponent(this Type value)
        {
            return value.GetType().GetCustomAttributes(typeof (ComponentAttribute), true).Length > 0;
        }

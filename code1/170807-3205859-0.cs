        private void BuildComponents(ContainerBuilder builder)
        {
            string currentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!Path.GetDirectoryName(assembly.Location).Equals(currentDirectory)) 
                    continue;
                foreach (var type in assembly.GetTypes())
                {
                    if (!type.IsComponent()) 
                        continue;
                    var imp = builder.RegisterType(type);
                    foreach (var @interface in type.GetInterfaces())
                        imp.As(@interface);
                    imp.SingleInstance();
                }
            }
        }

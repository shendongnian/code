            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().
                    Where(type => typeof(IParserBuilder).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.Transient);
            container.RegisterType<IEnumerable<IParserBuilder>, IParserBuilder[]>();

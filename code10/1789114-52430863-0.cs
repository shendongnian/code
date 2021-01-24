            var properties = typeof(Clientes_mdl).GetProperties();
            var propertyNames = properties
                .Where(x => x.PropertyType == typeof(string) ||
                            !x.PropertyType.IsClass ||
                            !typeof(IEnumerable).IsAssignableFrom(x.PropertyType)
                )
                .Select(x=>x.Name)
                .ToArray();
            var propertyNameString = string.Join("=@", propertyNames);

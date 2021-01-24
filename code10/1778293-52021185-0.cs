    private static Type GetOrCreateAnonymousTypeFor<TOriginal>(IEnumerable<PropertyInfo> propertyInfos)
    {
        var originalTypeName = typeof(TOriginal).Name;
        var propertyHash = string.Join(",", propertyInfos.OrderBy(x => x.Name).Select(x => x.Name));
        var typeKey = $"{originalTypeName} {propertyHash}";
        return CachedAnonymousTypes.GetOrAdd(typeKey, _ =>
        {
            var moduleBuilder = ModuleBuilder.Value;
            var typeName = Guid.NewGuid().ToString();
            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Serializable);
            foreach (var propertyInfo in propertyInfos)
                typeBuilder.DefineField(propertyInfo.Name, propertyInfo.PropertyType, FieldAttributes.Public);
            return typeBuilder.CreateType();
        });
    }

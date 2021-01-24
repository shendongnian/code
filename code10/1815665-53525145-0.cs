    IReadOnlyDictionary<TypeName, TypeMapping> backingDictionary = new ReadOnlyDictionary<TypeName, TypeMapping>(new Dictionary<TypeName, TypeMapping>
            {
                [typeName.Name] = typeMapping
            });           
            Type[] typeMappingsArgs = new Type[] { typeof(IConnectionConfigurationValues), typeof(IReadOnlyDictionary<TypeName, TypeMapping>) };
            object[] typeMappingsInputParams = new object[] { elasticClient.ConnectionSettings, backingDictionary };
            TypeMappings typeMappings = (TypeMappings)typeof(TypeMappings).GetConstructor(
                  BindingFlags.NonPublic | BindingFlags.Instance,
                  null, typeMappingsArgs, null).Invoke(typeMappingsInputParams);

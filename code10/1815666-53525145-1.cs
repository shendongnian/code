    private Nest.IGetMappingResponse GetFakeMappingResponse(Nest.IElasticClient elasticClient)
        {
            var fieldName = "fieldName";
            var indexName = "indexName";
            var documentTypeName = "documentTypeName";
            var typeMapping = new TypeMapping();
            var properties = new Properties();
            typeMapping.Properties = properties;
            var property = new TextProperty();
            property.Name = fieldName;            
            
            PropertyName propertyName = new PropertyName(fieldName);
            typeMapping.Properties.Add(propertyName, property);
            Type[] typeNameArgs = new Type[] { typeof(string) };
            object[] typeNameInputParams = new object[] { documentTypeName };
            TypeName typeName = (TypeName)typeof(TypeName).GetConstructor(
                  BindingFlags.NonPublic | BindingFlags.Instance,
                  null, typeNameArgs, null).Invoke(typeNameInputParams);
            IReadOnlyDictionary<TypeName, TypeMapping> backingDictionary = new ReadOnlyDictionary<TypeName, TypeMapping>(new Dictionary<TypeName, TypeMapping>
            {
                [typeName.Name] = typeMapping
            });           
            Type[] typeMappingsArgs = new Type[] { typeof(IConnectionConfigurationValues), typeof(IReadOnlyDictionary<TypeName, TypeMapping>) };
            object[] typeMappingsInputParams = new object[] { elasticClient.ConnectionSettings, backingDictionary };
            TypeMappings typeMappings = (TypeMappings)typeof(TypeMappings).GetConstructor(
                  BindingFlags.NonPublic | BindingFlags.Instance,
                  null, typeMappingsArgs, null).Invoke(typeMappingsInputParams);
            
            IndexMappings indexMappings = new IndexMappings();
            typeof(IndexMappings).GetProperty("Mappings", BindingFlags.Public | BindingFlags.Instance).SetValue(indexMappings, typeMappings);
            ReadOnlyDictionary<Nest.IndexName, Nest.IndexMappings> indices = new ReadOnlyDictionary<Nest.IndexName, Nest.IndexMappings>(new Dictionary<Nest.IndexName, Nest.IndexMappings>
            {
                [indexName] = indexMappings
            });
            var fakeMappingResponse = A.Fake<IGetMappingResponse>();
            A.CallTo(() => fakeMappingResponse.ServerError).Returns(null);
            A.CallTo(() => fakeMappingResponse.IsValid).Returns(true);
            A.CallTo(() => fakeMappingResponse.Indices).Returns(indices);
            return fakeMappingResponse;
        }

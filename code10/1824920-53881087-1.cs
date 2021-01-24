                SwaggerDocument gen = new SwaggerGenerator(apiDescriptionGroupCollectionProvider, schemaRegistryFactory, Swagger.SwaggerElements.GeneratorOptions.SwaggerGeneratorOptions).GetSwagger(version);
    
    
                var jsonBuilder = new StringBuilder();
    
                var _swaggerSerializer = SwaggerSerializerFactory.Create(mvcJsonOptionsAccessor);
                using (var writer = new StringWriter(jsonBuilder))
                {
                    _swaggerSerializer.Serialize(writer, gen);
                    return Ok(jsonBuilder.ToString());
                }

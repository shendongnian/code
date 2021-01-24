        private static JsonConverter DiscountConverter()
        {
            var assembly = Assembly.GetAssembly(typeof(ProductDiscount));
            var builder = JsonSubtypesConverterBuilder
                .Of(typeof(ProductDiscount), "Type");
            assembly
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(ProductDiscount)) && !type.IsAbstract)
                .ForEach(s =>
                {
                    builder.RegisterSubtype(s, s.Name);
                });
            var converter = builder
                .SerializeDiscriminatorProperty()
                .Build();
            return converter;
        } 

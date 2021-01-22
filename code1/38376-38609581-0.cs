        public static IEnumerable<TypeInfo> GetAtributedTypes( Assembly[] assemblies, 
                                                               Type attributeType )
        {
            var typesAttributed =
                from assembly in assemblies
                from type in assembly.DefinedTypes
                where type.IsDefined(attributeType, false)
                select type;
            return typesAttributed;
        }

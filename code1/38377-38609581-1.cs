        public static IEnumerable<TypeInfo> GetAtributedTypes( Assembly[] assemblies, 
                                                               Type attributeType )
        {
            foreach (var assembly in assemblies)
            {
                foreach (var typeInfo in assembly.DefinedTypes)
                {
                    if (typeInfo.IsDefined(attributeType, false))
                    {
                        yield return typeInfo;
                    }
                }
            }
        }

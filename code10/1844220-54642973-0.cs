csharp
        public class TypeWithSelfReference
        {
            public TypeWithSelfReference(TypeDefinition type, TypeReference reference)
            {
                Type = type;
                Reference = reference;
            }
            public TypeDefinition Type { get; }
            public TypeReference Reference { get; }
            public void Deconstruct(out TypeDefinition type, out TypeReference derived)
            {
                type = Type;
                derived = Reference;
            }
        }
        public static List<TypeWithSelfReference> GetHierarchy(this TypeDefinition typeDefinition, Func<TypeDefinition, bool> breakCondition)
        {
            var hierarchy = new List<TypeWithSelfReference>();
            foreach (var definition in typeDefinition.Traverse())
            {
                hierarchy.Add(new TypeWithSelfReference(definition, null));
                if (breakCondition(definition))
                    break;
            }
            hierarchy.Reverse();
            for (var i = 0; i < hierarchy.Count - 1; i++)
            {
                hierarchy[i] = new TypeWithSelfReference(hierarchy[i].Type, hierarchy[i + 1].Type.BaseType);
            }
            return hierarchy.Take(hierarchy.Count - 1).ToList();
        }
        private static TypeReference ResolveGenericParameter(IEnumerable<TypeWithSelfReference> hierarchy, GenericParameter parameter)
        {
            foreach (var (type, reference) in hierarchy)
            {
                foreach (var genericParameter in type.GenericParameters)
                {
                    if (genericParameter != parameter)
                        continue;
                    var nextArgument = ((GenericInstanceType) reference).GenericArguments[genericParameter.Position];
                    if (!(nextArgument is GenericParameter nextParameter))
                        return nextArgument;
                    parameter = nextParameter;
                    break;
                }
            }
            return null;
        }

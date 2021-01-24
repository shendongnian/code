    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        // Do not handle properties (it's difficult to concieve of a time when properties should be serialised at all).
        if(member is PropertyInfo)
        {
            return property;
        }
        else if(member is FieldInfo)
        {
            FieldInfo field = ((FieldInfo)member);
            // Does this field implement IList? This Utility function gets all member interfaces and checks if any of them equal the argued interface.
            if (field.FieldType.ImplementsInterface<IList>())
            {
                // Are the elements of this IList decorated with [Ref]?
                if (field.FieldType.GetGenericArguments()[0].HasAttribute<RefAttribute>())
                {
                    // Does this collection field have [Def]?
                    if (field.HasAttribute<DefAttribute>())
                    {
                        // This is a collection of definitions.
                        property.Converter = new DefCollectionJConverter();
                    }
                    else
                    {
                        // This is a collection of references.
                        property.Converter = new RefCollectionJConverter();
                    }
                }
            }
            else
            {
                // If the field's type class has been decorated with Ref.
                if (field.FieldType.HasAttribute<RefAttribute>())
                {
                    if (member.HasAttribute<DefAttribute>())
                    {
                        // If this particular field also has Def, it's a definition.
                        property.Converter = new DefinitionJConverter();
                    }
                    else
                    {
                        // Else it's a reference.
                        property.Converter = new ReferenceJConverter();
                    }
                }
            }
        }
        return property;
    }

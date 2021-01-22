    static readonly Type compilerGeneratedAttributeType = typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute);
    static bool IsDefered(IEnumerable enumerable)
    {
        if (enumerable == null) throw new ArgumentNullException("enumerable");
        var type = enumerable.GetType();
        var compilerGenerated = type.GetCustomAttributes(compilerGeneratedAttributeType, false).Length > 0;
        return type.IsNestedPrivate &&
            (
                type.Name.Contains("__") && compilerGenerated
                || type.DeclaringType.Equals(typeof(Enumerable))
            );
    }
        }

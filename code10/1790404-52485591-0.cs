    if (property.ValueGenerated == ValueGenerated.OnAdd
        && property.ClrType.UnwrapNullableType().IsInteger()
        && !HasConverter(property))
    {
    
        yield return new Annotation(SqliteAnnotationNames.Autoincrement, true);
    }

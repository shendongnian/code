    private bool IsNullableType(Type theType)
    {
        return (theType.IsGenericType &&
                theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
    }

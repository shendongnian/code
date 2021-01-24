    object obj = new GenericEnumViewModel<TestEnum>();
    var objType = obj?.GetType();
    var enumType =
        objType != null && objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(GenericEnumViewModel<>) ?
        objType.GetGenericArguments()[0] :
        throw new InvalidOperationException($"Object is not a closed type of {typeof(GenericEnumViewModel<>).FullName}");

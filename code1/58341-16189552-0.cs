    Type inputType = o.GetType();
    Type genericType;
    if ((inputType.Name.StartsWith("IEnumerable"))
        && ((genericType = inputType.GenericTypeArguments.FirstOrDefault()) != null)) {
        return genericType;
    } else {
        return inputType;
    }

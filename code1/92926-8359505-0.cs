    private static IEnumerable<object> SafeArrayToEnmrble (object comObject)
    {
        Type comObjectType = comObject.GetType();
        // spot here what is the type required
        if (comObjectType != typeof(object[,]))
        // return empty array, throw exception or whatever is your fancy
            return new object[0];
        int count = (int)comObjectType.InvokeMember("Length", BindingFlags.GetProperty, null, comObject, null);
        var result = new List<object>(count);
        var indexArgs = new object[2];
        for (int i = 1; i <= count; i++)
        {
            indexArgs[0] = i;
            indexArgs[1] = 1;
            object valueAtIndex = comObjectType.InvokeMember("GetValue", BindingFlags.InvokeMethod, null, comObject, indexArgs);
            result.Add(valueAtIndex);
        }
        return result;
    }

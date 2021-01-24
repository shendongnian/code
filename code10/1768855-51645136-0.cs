    public T Read<T>(ItemId itemId)
    {
        var type = Type.GetType(itemId.NameOfType);
        var methodInfo = typeof(DaClient).GetMethod("Read");
        var generic = methodInfo.MakeGenericMethod(type);
        dynamic readEvent = generic.Invoke(_client, new object[] { itemId.Tag });
       
        var value = readEvent.Value;
        return (T)value;
    }

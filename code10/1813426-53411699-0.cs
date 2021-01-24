    public async Task<object> ResolveQuery(ApiQuery message)
    {
        var type = Type.GetType(message.QueryType, true);
        var query = this.serializer.Deserialize(message.Payload, type);
        var interfaceType = type.GetGenericInterfaces(typeof(IQuery<>)).Single();
        var responseType = interfaceType.GetGenericArguments().Single();
        var handleMethod =     typeof(IQueryBus).GetMethod("ResolveAsync").MakeGenericMethod(responseType);
        var task = (Task)handleMethod.Invoke(this.bus, new object[] { query });
        await task;
        return typeof(Task<>).MakeGenericType(responseType).GetProperty("Result").GetValue(task);
    }

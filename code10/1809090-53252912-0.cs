    public TResult Process<TResult>(IQuery<TResult> query)
    {
        var handlerType = typeof(IQueryHandler<,>)
            .MakeGenericType(query.GetType(), typeof(TResult));
        dynamic handler = container.GetInstance(handlerType);
        return handler.Handle((dynamic)query);
    }

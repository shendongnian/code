    public Task<TResult> Execute<TResult>(IRequest<TResult> request)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResult));
        dynamic handler = _services.GetRequiredService(handlerType);
        return handler.ExecuteAsync((dynamic)query);
    }

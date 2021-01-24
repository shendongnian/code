    var jsonSerializationSettings = ...;
    if (context.Result is ObjectResult objectResult)
    {
        var result = new ObjectResult(objectResult.Value)
        {
            ContentTypes = objectResult.ContentTypes,
            DeclaredType = objectResult.DeclaredType,
            StatusCode = objectResult.StatusCode,
            Formatters = new FormatterCollection<IOutputFormatter>(objectResult.Formatters)
        };
        result.Formatters.RemoveType<JsonOutputFormatter>();
        result.Formatters.Add(new JsonOutputFormatter(jsonSerializationSettings, ArrayPool<char>.Shared));
        context.Result = result;
    }

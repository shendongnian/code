    public void OnResultExecuting(ResultExecutingContext context)
    {
      var objectResult = context.Result as ObjectResult;
      if (objectResult != null)
      {
        var serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver()
        };
        var jsonFormatter = new JsonOutputFormatter(
            serializerSettings,
            ArrayPool<char>.Shared);
        objectResult.Formatters.Add(jsonFormatter);
      }
    }

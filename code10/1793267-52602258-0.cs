    app.Use(async (context, next) =>
    {
      if (context.Request.Headers.GetValues("X-Original-Host") != null)
      {
        var originalHost = context.Request.Headers.GetValues("X-Original-Host").FirstOrDefault();
        context.Request.Headers.Set("Host", originalHost);
      }
      await next.Invoke();
    });

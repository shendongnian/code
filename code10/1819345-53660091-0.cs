    // Because IIS automatically captures the user login, by the time the app is touched
    // in any request, the context (ctx) User is already present.
    app.Use(async (ctx, next) =>
    {
      if (ctx.User?.Identity?.IsAuthenticated == true)
      {
        NgUser opPrincipal = CustomStaticMethod.GetUserAD();
        ctx.User = opPrincipal;
      }
      // be sure to continue the rest of the pipeline!
      await next.Invoke();
    });

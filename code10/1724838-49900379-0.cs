          if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseExceptionHandler(
      builder =>
      {
        builder.Run(
                async context =>
                {
                  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                  context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                  var error = context.Features.Get<IExceptionHandlerFeature>();
                  if (error != null)
                  {
                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                  }
                });
      });
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();

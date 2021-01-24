    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IExceptionHelper exceptionHelper)
    {
     app.UseExceptionHandler(builder => builder.Run(async context =>
     {
         var error = context.Features.Get<IExceptionHandlerFeature>();
         //Resolved and available!
         exceptionHelper.AddApplicationError(error);
         await context.Response.WriteAsync(error.Error.Message);
     }));
    app.UseHttpsRedirection();
    app.UseMvc();

    public static class ExceptionalConfiguration
    {
        public static void UseExceptionalErrorPage(this IApplicationBuilder app)
        {
            // using exceptional to handle error pages
            app.Map(new PathString("/exceptions"), action => action.Use(async (context, next) =>
            {
                await ExceptionalMiddleware.HandleRequestAsync(context);
            }));
        }
    }
    
    // Startup class
    app.UseExceptional();
    app.UseExceptionalErrorPage();
    app.UseMvc();

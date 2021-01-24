            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    var user = context.User.Identity.Name;
                    DeveloperLogin(context).Wait();
                    await next.Invoke();
                });
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

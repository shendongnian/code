     var projectName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/v1/" + projectName + "/{controller=Home}/{action=Index}/{id?}");
            });

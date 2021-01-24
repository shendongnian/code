        private ControllerContext CreateDummyControllerContext(string controllerName)
        {
            var context = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    RequestServices = GetServiceProvider()
                },
                RouteData = new RouteData
                {
                    Values = {{"controller", controllerName}}
                },
                ActionDescriptor = new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
                {
                    RouteValues = new Dictionary<string, string>(),
                }
            };
            return context;
        }
		// see https://codeopinion.com/using-razor-in-a-console-application/
        private ServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton(PlatformServices.Default.Application);
            var environment = new HostingEnvironment
            {
                ApplicationName = Assembly.GetEntryAssembly().GetName().Name
            };
            services.AddSingleton<IHostingEnvironment>(environment);
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Clear();
                options.FileProviders.Add(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
            });
            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<DiagnosticSource>(new DiagnosticListener("Microsoft.AspNetCore"));
            services.AddLogging();
            services.AddMvc();
            return services.BuildServiceProvider();
        }

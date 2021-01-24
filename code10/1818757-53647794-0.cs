            private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);
            // Add application services. For instance:
            container.Register<IMyService, MyService>(Lifestyle.Scoped);
            container.Register<MyCustomActionFilter>(Lifestyle.Scoped);
            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);
        }

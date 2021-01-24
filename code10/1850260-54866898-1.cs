        public static IMvcBuilder ConfigureExternalControllers(this IMvcBuilder builder, ExternalControllerConfiguration controllerConfiguration = null)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            var externalControllerAssembly = typeof(ExternalController).Assembly;
            builder.AddApplicationPart(externalControllerAssembly);
            // Next part is optional. Is used to add controller as a service.
            // see: https://github.com/aspnet/AspNetCore
            // /Mvc/Mvc.Core/src/DependencyInjection/MvcCoreMvcBuilderExtensions.cs
            var feature = new ControllerFeature();
            builder.PartManager.PopulateFeature(feature);
            foreach (var controller in feature.Controllers
                .Where(w => w.Assembly == externalControllerAssembly)
                .Select(c => c.AsType()))
            {
                builder.Services.TryAddTransient(controller, controller);
            }
            // builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            // add default configuration
            if (controllerConfiguration == null)
                controllerConfiguration = new ExternalControllerConfiguration();
            builder.Services.AddSingleton<ExternalControllerConfiguration>(controllerConfiguration);
            return builder;
        }

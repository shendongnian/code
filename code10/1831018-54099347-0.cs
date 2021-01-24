        public SettingsValidator(
            IServiceProvider services,
            ILifetimeScope scope
        )
        {
            var types = scope.ComponentRegistry.Registrations
                .SelectMany(e => e.Services)
                .Select(s => s as TypedService)
                .Where(s => s.ServiceType.IsAssignableToGenericType(typeof(IConfigureOptions<>)))
                .Select(s => s.ServiceType.GetGenericArguments()[0])
                .Where(s => typeof(ISettings).IsAssignableFrom(s))
                .ToList();
            foreach (var t in types)
            {
                var option = services.GetService(typeof(IOptions<>).MakeGenericType(new Type[] { t }));
                option.GetPropertyValue("Value");
            }
        }

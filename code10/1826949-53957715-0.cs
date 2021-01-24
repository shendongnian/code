    // Your module
    public static class BusinessLayerBootstrapper 
    {
        public static void Bootstrap(Container container)
        {
            var registrations =
                from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.Name.EndsWith("Service")
                from service in type.GetInterfaces()
                select new { service, type };
            foreach (var reg in registrations) {
                container.Register(reg.service, reg.type, Lifestyle.Scoped);
        }
    }

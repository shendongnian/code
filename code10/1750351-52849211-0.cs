     public static class SlightDIModuleConfigExtension
    {
         public static IWebHostBuilder UseSlightDIModuleconfig(this IWebHostBuilder webHostBuilder)
        {
           
            return webHostBuilder.ConfigureServices(services =>
            {
                foreach (Type type in Assembly.GetEntryAssembly()
                 .GetTypes()
                 .Where(myType => myType.IsSubclassOf(typeof(SlightModuleConfigure))))
                {
                    var instance = Activator.CreateInstance(type);
                    MethodInfo mi = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    mi.Invoke(instance, new object[] { services });
                }
            });
        }
    }

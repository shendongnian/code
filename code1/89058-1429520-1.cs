     internal static void Configure(IoCContainer ioc, Assembly assembly)
     {
         foreach (var type in assembly.GetTypes())
              AddToIoCIfHasComponentAttribute(type, ioc);
     }
     internal static void AddToIoCIfHasComponentAttribute(Type type, IoC ioc)
     {
         foreach (ComponentAttribute att in type.GetCustomAttributes(typeof(ComponentAttribute), false))
         {
              ioc.ConfigureMapping(attribute.InterfaceType, type);
         }
     }

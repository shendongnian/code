    public static class WindsorTestingExtensions
    {
        public static IHandler[] GetAllHandlers(this IWindsorContainer container)
        {
            return container.GetHandlersFor(typeof(object));
        }
        public static IHandler[] GetHandlersFor(this IWindsorContainer container, Type type)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }
        public static Type[] GetImplementationTypesFor(this IWindsorContainer container, Type type)
        {
            return container.GetHandlersFor(type)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }
    }

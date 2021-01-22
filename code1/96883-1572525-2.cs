    public static class IoC
    {
         private static IContainer innerContainer;
         
         public static void Initialize(IContainer container)
         {
              innerContainer = container;
         }
         public static T Resolve<T>()
         {
              return innerContainer.Resolve<T>();
         }
         // wrap more container methods here
    }

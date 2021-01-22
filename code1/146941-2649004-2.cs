    public class SomePlugin
    {
     public SomePlugin(IServiceProvider serviceProvider)
     {
      _foo = serviceProvider.GetService(typeof(IFoo)) as IFoo;
     }
    }

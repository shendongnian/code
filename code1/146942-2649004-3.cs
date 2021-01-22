    public class SomePlugin
    {
     public SomePlugin()
     {
      _foo = ServiceLocator.Current.GetService(typeof(IFoo)) as IFoo;
     }
    }

    public class MyClass
    {
      private readonly MyBackgroundService _service;
      public MyClass(IHostedServiceAccessor<MyBackgroundService> accessor)
      {
        _service = accessor.Service ?? throw new ArgumentNullException(nameof(accessor));
      }
    }

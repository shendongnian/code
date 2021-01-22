    public class MyTypeDescriptionProvider<T> : TypeDescriptionProvider
    {
      public MyTypeDescriptionProvider()
        : base(TypeDescriptor.GetProvider(typeof(T)))
      {
      }
    }

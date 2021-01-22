    public class MyTypeDescriptionProvider : TypeDescriptionProvider
    {
      public MyTypeDescriptionProvider(Type t)
        : base(TypeDescriptor.GetProvider(t))
      {
      }
    }

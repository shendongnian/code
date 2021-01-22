    internal interface IOptional
    {
      T? Get<T>(string id) where T : struct;
      T GetRef<T>(string id) where T : class;
      IOptional Set<T>(string id, T value);
      IOptional Clear(string id);
    }
    internal sealed class OptionalNone : IOptional
    {
      public static readonly OptionalNone Default = new OptionalNone();
      public T? Get<T>(string id)  where T : struct
      { 
        return null;
      }
      public T GetRef<T>(string id)  where T : class
      {
        return null;
      }
      public IOptional Set<T>(string id, T value)
      {
        if (value == null)
          return Clear(id);
        return new OptionalWithOne<T>(id, value);
      }
      public IOptional Clear(string id)
      {
        return this; // no effect
      }
    }
  
   

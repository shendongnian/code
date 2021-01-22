    internal sealed class OptionalWithOne<X> : IOptional
    {
      private string id1;
      private X value1;
 
      public OptionalWithOne(string id, X value)
      {
        this.id1 = id;
        this.value1 = value;
      }
      public T? Get<T>(string id)  where T : struct
      { 
        if (string.Equals(id, this.id1))
          return (T)(object)this.value1;
        return null;
      }
      public T GetRef<T>(string id)  where T : class        
      {
        if (string.Equals(id, this.id1))
          return (T)(object)this.value1;
        return null;
      }
      public IOptional Set<T>(string id, T value)
      {
        if (string.Equals(id, this.id1))
        {
          if (value == null)
            return OptionalNone.Default;
          this.value1 = (X)(object)value;
          return this;
        }
        else
        {
          if (value == null)
            return this;
          return new OptionalWithTwo<X,T>(this.id1, this.value1, id, value);
        }
      }
      public IOptional Clear(string id)
      {
        if (string.Equals(id, this.id1))
          return OptionalNone.Default;
        return this; // no effect
      }
    }
  

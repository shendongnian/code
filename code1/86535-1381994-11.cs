    internal sealed class OptionalWithTwo<X,Y> : IOptional
    {
      private string id1;
      private X value1;
      private string id2;
      private Y value2;
      public OptionalWithTwo(
        string id1, X value1,
        string id2, Y value2)
      {
        this.id1 = id1;
        this.value1 = value1;
        this.id2 = id2;
        this.value2 = value2;
      }
      public T? Get<T>(string id)  where T : struct
      { 
        if (string.Equals(id, this.id1))
          return (T)(object)this.value1;
        if (string.Equals(id, this.id2))
          return (T)(object)this.value2;
        return null;
      }
      public T GetRef<T>(string id)  where T : class        
      {
        if (string.Equals(id, this.id1))
          return (T)(object)this.value1;
        if (string.Equals(id, this.id2))
          return (T)(object)this.value2;
        return null;
      }
      public IOptional Set<T>(string id, T value)
      {
        if (string.Equals(id, this.id1))
        {
          if (value == null)
            return Clear(id);
          this.value1 = (X)(object)value;
          return this;
        }
        else if (string.Equals(id, this.id2))
        {
          if (value == null)
            return Clear(id);
          this.value2 = (Y)(object)value;
          return this;
        }
        else
        {
          if (value == null)
            return this;
          return new OptionalWithMany(
            this.id1, this.value1,
            this.id2, this.value2,
            id, value);
        }
      }
      public IOptional Clear(string id)
      {
        if (string.Equals(id, this.id1))
          return new OptionalWithOne<Y>(this.id2, this.value2);
        if (string.Equals(id, this.id2))
          return new OptionalWithOne<X>(this.id1, this.value1);
        return this; // no effect
      }
    } 
    

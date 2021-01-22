    internal sealed class OptionalWithMany : IOptional
    {
      private List<string> ids = new List<string>();
      // this boxes, if you had a restricted set of data types 
      // you could do a per type list and map between them
      // it is assumed that this is sufficiently uncommon that you don't care
      private List<object> values = new List<object>();
    
      public OptionalWithMany(
        string id1, object value1,
        string id2, object value2,
        string id3, object value3)
      {
        this.ids.Add(id1);
        this.values.Add(value1);
        this.ids.Add(id2);
        this.values.Add(value2);
        this.ids.Add(id3);
        this.values.Add(value3);
      }
      public T? Get<T>(string id)  where T : struct
      { 
        for (int i= 0; i < this.values.Count;i++)
        { 
          if (string.Equals(id, this.ids[i]))
            return (T)this.values[i];
        }
        return null;
      }
      public T GetRef<T>(string id)  where T : class        
      {
        for (int i= 0; i < this.values.Count;i++)
        { 
          if (string.Equals(id, this.ids[i]))
            return (T)this.values[i];
        }
        return null;
      }
      public IOptional Set<T>(string id, T value)
      {
        for (int i= 0; i < this.values.Count;i++)
        { 
          if (string.Equals(id, this.ids[i]))
          {
            if (value == null)
              return Clear(id);           
            this.values[i] = value;
            return this;
          }
        }
        if (value != null)
        {
          this.ids.Add(id);
          this.values.Add(value);
        }  
        return this;  
      }
      public IOptional Clear(string id)
      {
        for (int i= 0; i < this.values.Count;i++)
        { 
          if (string.Equals(id, this.ids[i]))
          {
            this.ids.RemoveAt(i);
            this.values.RemoveAt(i);
            return ShrinkIfNeeded();
          }
        }
        return this; // no effect
      }
      
      private IOptional ShrinkIfNeeded()
      {
        if (this.ids.Count == 2)
        {
          //return new OptionalWithTwo<X,Y>(
          // this.ids[0], this.values[0],
          //  this.ids[1], this.values[1]);
          return (IOptional)
            typeof(OptionalWithTwo<,>).MakeGenericType(
              // this is a bit risky. 
              // your value types may not use inhertence
              this.values[0].GetType(),
              this.values[1].GetType())
            .GetConstructors().First().Invoke(
              new object[] 
              {
                this.ids[0], this.values[0],
                this.ids[1], this.values[1]
              });
        }
        return this;
      }
    }   

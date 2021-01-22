    public T Value
    {
       get
       {
          if(_wrappedObject.Values.Length > 1)
             return (T)(object)_wrappedObject.Value; //T could be float[]. this doesn't compile.
          else
             return (T)_wrappedObject.Values[0]; //T could be float. this compiles.
       }
    }

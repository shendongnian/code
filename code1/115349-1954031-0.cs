I'm also not clear on the point of your Member.Name<IAmAnAsset>(x => ...) construct.  
    void Copy<D,S,V>(D dest, S source, Action<S> getVal, Action<D,V> setVal, IValidationDictionary validationDictionary)
    {
      try 
      {
        setVal(dest, getVal(source));
      } 
      catch (System.Exception exception)
      {
        validationDictionary.AddError(Member.Name<IAmAnAsset>(lIAmAnAsset => lIAmAnAsset.AssetTag), exception.Message);
      }
    }

I'm also not clear on the point of your Member.Name&lt;IAmAnAsset&gt;(x => ...) construct.  
[Edit] -> It looks like you're using the above construct instead of constants.  If that is correct, why not create a class letting you do this instead: AssetNames.AssetTag?
    void Copy<D,S,V>(D dest, S source, Function<S,V> getVal, Action<D,V> setVal, IValidationDictionary validationDictionary)
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

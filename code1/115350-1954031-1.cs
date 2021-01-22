    public static ModelAsset CreateAssetDomain(IAmAnAsset asset, IValidationDictionary validationDictionary) 
    { 
      var result=new ModelAsset();
      var validationCount = validationDictionary.Count();
      Copy(result, asset, x=>asset.AssetTag, (x,v)=>x.AssetTag = v, validationDictionary);
      Copy(result, asset, x=>asset.LocationIdentifier, (x,v)=>x.LocationIdentifier = v, validationDictionary);
      
      if (validationCount < validationDictionary.Count)
        throw new ArgumentException("Failed validation"); 
      return result; 
    }

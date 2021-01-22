    public static Dictionary<string, object> DictionaryFromType(object atype, 
         Dictionary<string, object[]> indexers)
    {
         /* replace GetValue() call above with: */
         object value = prp.GetValue(atype, ((indexers.ContainsKey(prp.Name)?indexers[prp.Name]:new string[]{});
    }

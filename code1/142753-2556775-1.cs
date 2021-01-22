    public string ConvertToCustomTypeName(ObjectTypes typeObj)
    {
         // Shouldn't need TryGetValue, unless you're expecting people to mess  with your enum values...
         return enumLookup[typeObj];
    }

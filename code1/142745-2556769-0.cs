    internal static string MapToName(ObjectTypes value) {
      switch (value) { 
        case ObjectTypes.TypeOne: return "T123";
        case ObjectTypes.TypeTwo: return "T234";
        ...
      }
    }
    
    public string ConvertToCustomTypeName(ObjectTypes value) {
      return String.Format("This is type {0}", MapToName(value));
    }

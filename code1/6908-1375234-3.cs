    public List<Enum> GetValues(Enum enumeration)
    {
       List<Enum> enumerations = new List<Enum>();
       foreach (FieldInfo fieldInfo in enumeration.GetType().GetFields(
             BindingFlags.Static | BindingFlags.Public))
       {
          enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
       }
       return enumerations;
    }

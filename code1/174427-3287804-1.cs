    //converts enum to dictionary of values
    public static class EnumExtensions
    {        
        public static IDictionary ToDictionary<TEnumValueType>(this Website e)
        {                        
            if(typeof(TEnumValueType).FullName != Enum.GetUnderlyingType(e.GetType()).FullName) throw new ArgumentException("Invalid type specified.");
    
            return Enum.GetValues(e.GetType())
                        .Cast<object>()
                        .ToDictionary(key => Enum.GetName(e.GetType(), key), 
                                      value => (TEnumValueType) value);            
        }
    }

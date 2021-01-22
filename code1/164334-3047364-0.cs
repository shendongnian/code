    public static class Enums 
        { 
            public static T GetCode<T>(string value) 
            { 
                foreach (object o in System.Enum.GetValues(typeof(T))) 
                { 
                    if (((Enum)o).GetStringValue() == value.ToUpper()) 
                        return (T)o; 
                } 
                throw new ArgumentException("No code exists for type " + typeof(T).ToString() + " corresponding to value of " + value); 
            } 
    }  

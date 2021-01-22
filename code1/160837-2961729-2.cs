    /// <summary> 
    /// Checks the specified value to see if it can be 
    /// converted into the specified type. 
    /// <remarks> 
    /// The method supports all the primitive types of the CLR 
    /// such as int, boolean, double, guid etc. as well as other 
    /// simple types like Color and Unit and custom enum types. 
    /// </remarks> 
    /// </summary> 
    /// <param name="value">The value to check.</param> 
    /// <param name="type">The type that the value will be checked against.</param> 
    /// <returns>True if the value can convert to the given type, otherwise false. </returns> 
    public static bool CanConvert(string value, Type type) 
    { 
        if (string.IsNullOrEmpty(value) || type == null) return false;
        System.ComponentModel.TypeConverter conv = System.ComponentModel.TypeDescriptor.GetConverter(type);
        if (conv.CanConvertFrom(typeof(string)))
        { 
            try 
            {
                conv.ConvertFrom(value); 
                return true;
            } 
            catch 
            {
            } 
         } 
         return false;
      }

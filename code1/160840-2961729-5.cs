     public static bool Is<T>(this string value)
     {
        if (string.IsNullOrEmpty(value)) return false;
        var conv = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
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

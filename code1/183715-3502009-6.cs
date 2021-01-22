    public static class EnumConverter<T>
    {
        public static T ToEnum(char charToConvert, out bool success)
        {
            try
            {                
                int intValue = Convert.ToInt32(charToConvert);                
                if (Enum.IsDefined(typeof(T), intValue))
                {
                    success = true;
                    return (T)Enum.ToObject(typeof(T), intValue);
                }
           }
           catch (ArgumentException ex)
           {
                   // Use your own Exception Management Here
           }
           catch (InvalidCastException ex)
           {
               // Use your own Exception Management Here
           }
           success = false;
           return default(T);
        }
    }

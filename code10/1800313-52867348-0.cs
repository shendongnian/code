    static object HandleEnumViaGeneric<T>(T e)
    {
        var genType = typeof(T);
        if(genType.IsEnum)
        {
           foreach (T object in Enum.GetValues(genType))
           {
               Enum temp =  Enum.Parse(typeof(T), e.ToString()) as Enum;
               return Convert.ToInt32(temp);
           }
         }
    }

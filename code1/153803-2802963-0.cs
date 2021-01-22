    Type myListType = list.GetType().GetGenericArguments()[0];
    // or Type myListType = typeof(T); as stated by Kobi
    if(myListType == typeof(SomeArbitraryType))
    {
       var typedList = list.Cast<SomeArbitraryType>();
       // do something interesting with your new typed list.
    }

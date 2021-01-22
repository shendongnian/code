    List<object> listObject = new List<object>();
    listObject.Add("ITEM 1");
    listObject.Add("ITEM 2");
    listObject.Add("ITEM 3");
    List<string> listString = Converter.ConvertToGenericList<string>(listObject);

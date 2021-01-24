    foreach (var element in ListOfObjects)
    {
        var type = Type.GetType(element.Name);
        if (type == typeof(YOUR_OBJECT_TYPE))
        {
               // Do Something
        }
       
    }

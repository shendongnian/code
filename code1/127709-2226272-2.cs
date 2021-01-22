    var prop1 = typeof (Customer).GetProperty("Invoice");
    
    // if you need it for something...
    var listElementType = prop1.PropertyType.GetGenericArguments()[0];
    
    IList list1;
    
    
    object obj = prop1.GetValue(object1, null);
    
    if(obj is PersistentBag)
    {
        list1 = (PersistentBag)obj;
    }
    else 
    {
        list1 = (IList)obj;
    }
    
    foreach (object item in list1)
    {
        // do whatever you wanted.
    }

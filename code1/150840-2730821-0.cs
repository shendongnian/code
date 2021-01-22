    Item item = new Item();
    foreach (PropertyInfo info in item.GetType().GetProperties())
    {
       if (info.CanRead)
       {
          object o = propertyInfo.GetValue(myObject, null);
       }
    }

    Item item = new Item();
    foreach (PropertyInfo info in item.GetType().GetProperties())
    {
       if (info.CanRead)
       {
          // To retrieve value 
          object o = info.GetValue(myObject, null);
          // To Set Value
          info.SetValue("SKU", "NewValue", null);
       }
    }

    foreach (PropertyInfo info in myObject.GetType().GetProperties())
    {
       if (info.CanRead)
       {
          object o = propertyInfo.GetValue(myObject, null);
       }
    } 

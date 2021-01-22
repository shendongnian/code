    public static void CopyObject(object source, object destination)
    {
       var props = source.GetType().GetProperties();
    
       foreach (var prop in props)
       {
           PropertyInfo info = destination.GetType().GetProperty(prop.Name);
           if (info != null)
           {
               info.SetValue(destination, prop.GetValue(source, null), null);
           }
       }
    }

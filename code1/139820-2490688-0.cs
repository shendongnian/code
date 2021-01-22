    var t = this;
    var props = t.GetType().GetProperties();
    foreach (var prop in props)
    {
        if (prop.PropertyType == typeof(DateTime))
        {
            //do stuff like prop.SetValue(t, DateTime.Now, null);
            
        }
    }

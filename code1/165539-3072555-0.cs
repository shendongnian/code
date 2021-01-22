    Type typeR = r.GetType();
    Type typeThis = this.GetType();
    
    foreach (PropertyInfo p in t.GetProperties())
    {
        PropertyInfo thisProperty = typeThis.GetProperty(p.Name);
        thisProperty.SetValue(this, p.GetValue(), null);
    }

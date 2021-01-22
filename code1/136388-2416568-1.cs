    public T GetDatos(String NamedObject)
    {
        return (T)HttpContext.Current.Session[NamedObject];
    }
    public void SetDatos(String NamedObject, T Value)
    {
        HttpContext.Current.Session[NamedObject] = Value;
    }

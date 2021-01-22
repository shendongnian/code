    public static dynamic dogs
    {
        get {
        var eo = new ExpandoObject() as IDictionary<string,object>;
        foreach( var value in Enum.GetValues(typeof(Animal)).Cast<Animal>().Where(a => a.IsDog()))
            eo[value.ToString()] = value;
            
        return eo;
        }
    }
    public static dynamic cats
    {
        get {
        var eo = new ExpandoObject() as IDictionary<string,object>;
        foreach( var value in Enum.GetValues(typeof(Animal)).Cast<Animal>().Where(a => a.IsCat()))
            eo[value.ToString()] = value;
            
        return eo;
        }
    }

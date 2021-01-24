    public string getName(object ob)
    {
        var type = ob.GetType();
        if (type.GetProperty("Name") == null) return null;
        else return type.GetProperty("Name").GetValue(ob, null);
    }

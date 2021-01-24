    public void AddObject(object obj)
    {
        if (!objs.ContainsKey(obj.GetType()))
        {
            objs[obj.GetType()] = new List<object>() { obj };
        }
        else
        {
            objs[obj.GetType()].Add(obj);
        }
    }

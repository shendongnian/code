    public Module GetByName(string name)
    {
        foreach(var m in modules)
        {
            if(string.Equals(m.name, name)) return m;
        }
        return null;
    }
    public Module GetByName(int difficulty)
    {
        foreach(var m in modules)
        {
            if(m.difficulty == difficulty) return m;
        }
        return null;
    }

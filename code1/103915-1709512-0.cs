    public StringBuilder MakeString(IEnumerable<CoolType> list)
    {
        StringBuilder sb = new StringBuilder();
    
        foreach(var whatever in list)
        {
            sb.Append("{0}", whatever);
        }
    }
    var sb = MakeString(whateverList);
    // Do stuff
    // Clear stuff
    sb = MakeString(whateverList2);

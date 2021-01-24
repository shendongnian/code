    private int CompareProps(Object a, Object b)
    {
        int matchedElements = 0;
        var props = a.GetType().GetProperties();
        foreach(var prop in props)
        {
            var vala = prop.GetValue(a);
            var valb = prop.GetValue(b);
            if(vala == valb)
                matchedElements++;
    
        // More Property Comparisons...
        return matchedElements;
    }

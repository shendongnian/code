    private void CheckAll(IEnumerable<Object1> result)
    {
        foreach(var w in result)
        {
            if(w.CheckIt())
            {
                // do something
            }
        }
    }

    public void DoStuff(List<int> list)
    {
        CheckPreconditions(list);
        double ans = Calculate(list);        
    }
    
    private void CheckPreconditions(List<int> list)
    {
        if(list == null)
           // throw ...
        if(list.Length == 0)
           // throw ...
        if(Length < list.Count)
            throw ArgumentException("list", 
                 "list must have blah blah blah to satisfy requirements");
    }

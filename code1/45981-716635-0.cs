    public List<object> GetStuff()
    {
        var results = from r in _context.Result
        select new
        {
            State = r.StateNavigationProperty.StateLabel, //If FK
            State = _context.State.First(state => state.StateId == r.StateId), //If Not FK
            HostAddress = r.ServerReference.Value.HostAddress,
            TimeStamp = r.TimeStamp
        };
    
        return results.Cast<object>().ToList();
    }
    
    ...
    
    myListView.DataSource = GetStuff();

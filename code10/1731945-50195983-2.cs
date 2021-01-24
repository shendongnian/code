    public void Notify()
    {
        foreach(RailwayUser u in _watches)
        {
            u.PrintClassName();
            u.Notice(State)
        }
    }

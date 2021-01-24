    public async void A()
    {
       await Task.Run(new Action(B))
    }
    public void B()
    {
       //Give source for listvView here
    }

    public void UsingDataContext (Action<DataContext> action)
    {
        using (DataContext ctx = new DataContext())
        {
           action(ctx)
        }
    }
    

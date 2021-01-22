    IDevice d;
    
    if(a == 1)
    {
       d = container.Resolve<IDevice>("Simulated")
    }
    else
    {
       d = container.Resolve<IDevice>("Actual")
    }
    
    User user = container.Resolve<IUser>();
    user.Device = d;

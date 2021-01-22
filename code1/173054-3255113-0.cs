    IDevice d;
    
    if(a == 1)
    {
       d = container.Resolve<SimulatedActualDevice>()
    }
    else
    {
       d = container.Resolve<ActualDevice>()
    }
    
    User user = container.Resolve<IUser>();
    user.Device = d;

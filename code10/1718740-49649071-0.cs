    public bool HasPower
    {
        get => Machines?.First().HasPower ?? false;
        set
        {
          foreach(var machine in Machines)
               machine.HasPower = value;
        }
    
    }

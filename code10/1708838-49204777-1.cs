    public string Name { get ; set; } // TODO: add usual property changed stuff
    void UpdateStuff()
    {
        // perhaps update Name and NameOpt here
        // ...
    
        // Now update the exposed property
        Name ? Name : NameOpt
    }

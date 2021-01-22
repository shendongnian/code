    public static ShipInfo FillDefaults()
    {
        ShipInfo newInstance = ...;
        // Do some default setup here
        return newInstance;
    }
    public ShipInfo CalculateSomething(int basis)
    {
        // Do some calculation
        // Assign some values internally
        return this;
    }
    // Keep following this pattern of methods
    public void ApplyTo(SpaceObject obj)
    {
        // Some checks here if you want
        obj.ShipInfo = this;
    }

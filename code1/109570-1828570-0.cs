    public enum Movement
    {
        Top,
        Average,
        Poor
    }
    public static Movement MovementForAnalysis(SalesAnalysis sa)
    {
        return sa.NumberOfUnits >= 30000 ? Movement.Top
             : sa.NumberOfUnits >= 10000 ? Movement.Average
             : Movement.Poor;
    }

    public enum Movement
    {
        Top,
        Average,
        Poor
    }
    public static Movement MovementForAnalysis(SalesAnalysis sa)
    {
        return sa.NumberOfUnitsSold >= 30000 ? Movement.Top
             : sa.NumberOfUnitsSold >= 10000 ? Movement.Average
             : Movement.Poor;
    }

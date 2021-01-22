    public enum StopLight: int
    {
        Red = 1,
        Yellow = 2,
        Green = 3
    }
    
    // ...
    
    int myStoplightColor = EnumHelpers.Convert<int, StopLight>(StopLight.Red);

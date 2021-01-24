    [Flags]
    public enum TestEnum
    {
        A = 1,
        B = 2,
        C = 4,
        D = 8,    
        All = A|B|C|D,  // or compute this inside the method    
    }

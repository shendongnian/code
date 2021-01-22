    [Serializable,Flags]
    public enum AccessLevels{    
    None = 1,    
    Read = 2,    
    Write = 4,    
    Full = Read | Write}

    // Define extension method like this:
    public static bool IsActive(this AccountStatus status)      
    {            
        get { return status == AccountStatusCode.Active; }      
    }
    // 
    // Call it like this:
    if (AccountStatus.IsActive())

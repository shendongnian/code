    public bool IsValid
    {
        get
        {
            return  DeleteFAQbyID();
        }
    }
    
    public abstract bool DeleteFAQbyID();

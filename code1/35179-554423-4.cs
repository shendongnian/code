    public EmploymentType? EmploymentType { get; set; } // Nullable Type
    public void PerformAction()
    {
        if(this.Validate())
            // Perform action
    }
    protected bool Validate()
    {
        if(!EmploymentType.HasValue)
            throw new InvalidOperationException("EmploymentType must be set.");
    }

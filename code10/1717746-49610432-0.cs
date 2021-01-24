    private ICollection<ProjectStep> projectSteps;
    [DataMember]
    public virtual ICollection<ProjectStep> ProjectSteps
    {
        get { return projectSteps; }
        set { projectSteps = value is ProjectStep[] ? value.ToList() : value; }
    }

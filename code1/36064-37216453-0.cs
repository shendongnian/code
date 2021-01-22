    public PatientMap()
    {
        HasMany(x => x.Insurances)
            .WithKeyColumn("uid_Patient")
            .Cascade.All();
    
        ...
    }
    
    public InsuranceMap()
    {
        References(x => x.Patient, "uid_Patient")
            .Not.Nullable()
            .Cascade.All();
    
        ...
    }

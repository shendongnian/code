    public static IEdmModel GetModel()
    {
        var builder = new ODataConventionModelBuilder();
        var skillSet = builder.EntitySet<Skill>(nameof(Skill));
        skillSet.EntityType.Ignore(x => x.RequestNegotiations);
        skillSet.EntityType.Ignore(x => x.UserSkills);
        
        builder.ContainerName = "DefaultContainer";
        return builder.GetEdmModel();
    } 

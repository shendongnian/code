    public List<UserRegistryModel> RegistryJoinAge()
    {
    
        List<UserRegistryModel> ListRegistry = new Registry().LoadRegistry()
        .select(x => new UserRegistryModel()
        {
            Number = x.Number,
            Description = x.Description,
            People_id = x.People_id,
            Age = AgeCalculation(x.People.birth_date)
        }).ToList();
    
        return ListRegistry;
    }

    IQueryable<Animal> animals = myDbContext.Animals;
    IEnumerable<QueryParam> inputParameters = new QueryParam[]
    {
        new QueryParam() {SpeciesId = 1, Value = cow},
        new QueryParam() {SpeciesId = 2, Value = cat},
    };

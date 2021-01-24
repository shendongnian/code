    enum PersonQuery
    {
        ByFirstname,
        ByAge,
        ByHasChildWithAgeOver,
        Skip,
    }
    public IReadOnlyDictionary<PersonQuery, Expression> CreateExpressions()
    {
        Dictionary<PersonQuery, Expression> dict = new Dictionary<PersonQuery, Expression>();
        using (var dbContext = new MyDbContext())
        {
             IQueryable<Person> queryByFirstName = dbContext.Persons
                 .Where(...);
             dict.Add(PersonQuery.ByfirstName, queryByFirstName.Expression);
             ... // etc for the other queries
        }
        return dict.
    }

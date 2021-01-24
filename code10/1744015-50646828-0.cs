    public virtual IEnumerable<Car> YourGetCarsWebApiEndpoint(ODataQueryOptions<Car> options)
    {
        var queryable = yourCarsRepository.Cars();
    
        // Explicitly apply OData options to queryable:
        queryable = (IQueryable<Car>)options.ApplyTo(queryable);
    
        var cars = queryable.ToList();
    
        // Do stuff:
    
        return cars;
    }

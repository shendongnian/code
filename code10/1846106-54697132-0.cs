    IQueryable<Car> query  = repository.Cars;
    if (!string.IsNullOrEmpty(brand))
    {
     query = query.Where(x => x.Brand  == brand);
    }
    if (!string.IsNullOrEmpty(model ))
    {
     query = query.Where(x => x.Model == model );
    }

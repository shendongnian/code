    IQueryable<T> query = ctx.SomeObjects;
    if(!string.IsNullOrEmpty(name)) {
        query = query.Where(x => x.Name == name);
    }
    if(activeOnly) {
        query = query.Where(x => x.IsActive);
    }
    if(minDate != DateTime.MinValue) {
        query = query.Where(x => x.Date >= minDate);
    }
    if(maxDate != DateTime.MinValue) {
        query = query.Where(x => x.Date <= maxDate);
    }
    List<T> results = query.ToList();

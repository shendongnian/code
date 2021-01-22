    if (_searchCriteria.ProductionStart > 0)
    {
        query.Add<Engine>(e => e.StartDate >= _searchCriteria.ProductionStart);
    }
    if (_searchCriteria.ProductionEnd > 0)
    {
        query.Add<Engine>(e => e.FinishDate <= _searchCriteria.ProductionEnd);
    }

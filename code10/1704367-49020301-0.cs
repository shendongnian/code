    // Create the filter query.
    IQueryable<TModel> modelQuery = _collection.AsQueryable()
        .Where(t => t.TeamId == teamId && t.CompanyId == companyId);
    
    // Get the query as it will be executed in MongoDB.
    var mquery = (MongoQueryable<TModel>)modelQuery; // This line shows the error below.
    var query = mquery.GetMongoQuery().ToJson();
    
    // Get the results.
    var models = modelQuery.ToList();
    // Get the executed query string.
    var executionModel = ((IMongoQueryable<TModel>)modelQuery).GetExecutionModel();
    var queryString = executionModel.ToString();

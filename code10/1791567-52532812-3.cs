    IEnumerable<DataPoint> FetchDataPoints(...)
    {
        return myDbContext.DataPoints
            // select a subset of dataPoints:
            // improve readability, use proper identifiers: not "ent", but "dataPoint"
            .Where(dataPoint => ...)         
             
            // select only the properties you plan to use in this use-case scenario
            .Select(dataPoint => new
            {
                Id = dataPoint.Id,
                Description = dataPoint.Description,
                EffectiveDate = dataPoint.EffectiveDate,
                ...
                DataPointStates = dataPoint.DataPointStates
                    // only Select the dataPointStates I plan to use
                    .Where(dataPointState => ...))
                    // from every dataPointSate select only the properties I plan to use
                    .Select(dataPointState => new
                    {
                        ...
                        // not needed: dataPointState.DataPointId, you know the value
                    })
                    .ToList(),
                // query only the DataPointExpressions you plan to use,
                DataPointExpressions = dataPoint.DataPointExpressions
                    .Where(dataPointExpression => ...)
                    .Select(dataPointExpression => new
                    {
                        // again select only the properties you plan to use
                    })
                    .ToList(),
            })

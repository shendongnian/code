            // continue the linq statement: put the transferred data in a type.
            .Select(fetchedData => new DataPoint
            {
                Description = fetchedData.Description,
                EffectiveDate = fetchedData..EffectiveDate,
                DataPointStates = fetchedData.DataPointStates,
                ...
                ConstraintFilters = getConditions(), 
            });
            // note: the result is an IEnumerable! no need to convert it to IQueryable
            // because an IEnumerable can do much more than an IQueryable
    }

        var usedOrderBy = true;
        foreach (var orderBy in orderBys)
        {
            if (usedOrderBy)
            {
                query = _list.OrderBy(orderBy);
                usedOrderBy = true;
            }
            else
                query = query.ThenBy(orderBy); 
        }

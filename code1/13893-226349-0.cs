        ProvideDefaultSorting(ref query);
        if (!IsSorted(query))
        {
                query = query.OrderBy(c => c.CategoryID);
        }

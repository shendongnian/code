    if (whereClause != null)
    {
        return new SelectedPhrases()
            {
                ps = ps.Where(whereClause).ToList(),
                psNoa = psNoa.Where(whereClause).ToList()
            };
    }
    else
    {
        return new SelectedPhrases()
            {
                ps = ps,
                psNoa = psNoa
            };
    }

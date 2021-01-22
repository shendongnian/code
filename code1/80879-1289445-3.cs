    Expression<Func<Committee, bool>> committeeWhere;
    if(committeeID.HasValue)
    {
        int id = committeeID.Value;
        committeeWhere = c => c.ID == id;
    }
    else
    {
        committeeWhere = c => true;
    }
    // etc

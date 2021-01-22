    var query = db.GetTable<Products>().AsQueryable();
    var predicate = PredicateBuilder.False<Products>();
    if (automotive.Checked)
    {
        predicate = predicate.Or( p => p.Automotive == 1 );
    }
    if (aviation.Checked) 
    {
        predicate = predicate.Or( p => p.Aviation == 1 );
    }
    query = query.Where( predicate );

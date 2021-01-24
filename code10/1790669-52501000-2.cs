    private static PredicateBuilder.False<RMAHistory> AbensagerPredicate(string searchingAbensager)
    {
        var predicate = PredicateBuilder.False<RMAHistory>();
        if (searchingAbensager == null) { return predicate; }
        int abensager;
        if (int.TryParse(searchingAbensanger, out abensager))
        {
            predicate = predicate.Or(p => p.Id = abensanger);
        }
        predicate = predicate.Or(p => p.Name.Contains(searchingAbensanger));
        return predicate;
    }
    public ActionResult Abensager(string searchingAbensager, int? pageNumber)
    {
        return db.RMAStatus.Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y })
            //.AsExpandable() // If using Entity Framework
            .Where(AbensagerPredicate(searchingAbensager));
    }

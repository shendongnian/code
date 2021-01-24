    public ActionResult Abensager(string searchingAbensager, int? pageNumber)
    {
        var predicate = PredicateBuilder.False<RMAHistory>();
        if (searchingAbensager != null)
        {
            int abensager;
            if (int.TryParse(searchingAbensanger, out abensager))
            {
                predicate = predicate.Or(p => p.Id = abensanger);
            }
            predicate = predicate.Or(p => p.Name.Contains(searchingAbensanger));
        }
        return db.RMAStatus.Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y })
            //.AsExpandable() // If using Entity Framework
            .Where(predicate);
    }

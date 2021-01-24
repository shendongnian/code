    public ActionResultAbensager(string searchingAbensager, int? pageNumber)
    {
        var query = db.RMAStatus.Join(
            db.RMA_History, 
            u => u.ID, y => y.StatusID, 
            (u, y) => new { u, y });
        if (searchingAbensager != null)
        {
            int abensager;
            if (int.TryParse(searchingAbensanger, out abensager))
            {
                query = query.Where(x => 
                    x.y.Id == abensager || 
                    x.y.Name.Contains(searchingAbensager));
            }
            else
            {
                query = query.Where(x =>
                    x.y.Name.Contains(searchingAbensanger));
            }
        }
    
        return View(query
            .Select(t => new RMAHistory { ... })
            .ToPagedList(pageNumber ?? 1, 10);
    }

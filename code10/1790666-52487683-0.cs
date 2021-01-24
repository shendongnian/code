    public ActionResult Abnesager(string searchingAbensager, int? pageNumber)              
    {
        IPagedList<RMAHistory> query = db.RMAStatus.Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y })
                                                   .Where(x => x.y.Id.ToString().Contains(searchingAbensager.Substring(2)) || x.y.Name.Contains(searchingAbensager) || searchingAbensager == null)
                                                   .Select(t => new RMAHistory
                                                   {
                                                       //Select Something
                                                   }).ToPagedList(pageNumber ?? 1, 10);
        return View(query);
    }

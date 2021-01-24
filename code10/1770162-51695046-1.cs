    public ActionResult Index(string searching)
    {
        var searchItems = searching.Split( new char[] {';',',',' '}, StringSplitOptions.RemoveEmptyEntries);
        return PartialView("Index",
            db.tblAuditFile2.Where(x=>searchItems.Contains(x.RefNo))
              .ToList());
    }

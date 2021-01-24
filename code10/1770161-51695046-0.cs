    public ActionResult Index(string searching)
    {
        int id;
        var searchItems = searching.Split( new char[] {';',',',' '})
              .Select(x => int.TryParse(x, out id)? id : -1);
        return PartialView("Index",
            db.tblAuditFile2.Where(x=>searchItems.Contains(x.RefNo))
              .ToList());
    }

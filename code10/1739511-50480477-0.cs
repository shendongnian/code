    public ActionResult Index()
    {
        using (DBEntities db = new DBEntities())
        {
            return View(db.vw_values.Where(m => values.Contains(m.value).ToList());
        }
    }

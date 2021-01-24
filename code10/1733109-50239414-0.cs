    using System.Linq
    
    public ActionResult Index()
    {
        return View(db.Blogs.ToList());
    }

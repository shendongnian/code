    DAL.DB dblayer = new DAL.DB();
    public ActionResult Index(string id)
    {
        DataSet ds1 = dblayer.GetClass(id);
        ViewBag.general = ds1.Tables[0];
        return View();
    }

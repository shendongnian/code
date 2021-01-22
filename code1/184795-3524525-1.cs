    [HttpPost]
    public ActionResult Index(IEnumerable<HttpPostedFileBase> files) 
    {
        foreach (var file in files) 
        {
            if (file.ContentLength > 0) 
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                file.SaveAs(path);
            }
        }
        return RedirectToAction("Index");
    }

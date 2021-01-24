    [HttpGet]
    public ActionResult ExportRecords(string[] id)
    {
        foreach(string value in  id)
        {
            System.Diagnostics.Debug.Writeline(value);
        } 
         return View();
    }

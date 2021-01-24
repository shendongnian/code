    [HttpPost]
    public ActionResult Request(Events e)
    {
        if (e.file1 != null && e.file1.ContentLength > 0)
        {
            // save the file
            return Content("Added");
        }
        else
        {
            // do something else
            return Content("Added");
        }
    }

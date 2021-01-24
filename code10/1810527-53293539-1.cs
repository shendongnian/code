    [HttpPost]
    public ActionResult Request(Events e)
    {
        if (Request.Files.Count > 0)
        {
            foreach (string files in Request.Files)
            {
                 if (!string.IsNullOrEmpty(files))
                 {
                     // save the file
                 }
            }
            return Content("Added");
        }
        else
        {
            // do something else
            return Content("Added");
        }
    }

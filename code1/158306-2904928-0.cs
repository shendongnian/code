    [HttpPost]
    public ActionResult Numbers(FormCollection fc)
    {
        foreach (string key in fc.Keys)
        {
            int i = Convert.ToInt32(key);
            // i = the number of the item that was selected.
        }
        return View();
    }

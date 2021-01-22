    public ActionResult Archive(int year)
    {
       if (!String.IsNullOrEmpty(Request["year"]))
       {
           return RedirectToAction("Archive", new { year = year });
       }
       if (year == 0)
       {
           /* ... */
       }
       /* ... */
    }

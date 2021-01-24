    public async Task<ActionResult> List(string searchString, int keyword)
    {
      //Your existing code
      ViewBag.Track = keyword;
      return View(await catalogs.ToListAsync());
    } 

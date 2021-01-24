    [HttpGet]
    public ActionResult View(int id)
    {
       var images = new List<Image>();
       var db = new portfolio_project_dbEntities())
       {
          images  = db.Images
                      .Where(x => x.UserId == id)
                      .ToList();
        }
        // images is a list of Image objects. Let's pass it to the view.
        return View(images);
     }

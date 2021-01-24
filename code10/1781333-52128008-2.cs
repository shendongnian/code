    public ActionResult Details(int? Id)
    {
        //This will return single movie with your parameter id
        var mvz = _context.mvz.SingleOrDefault(a => a.Id == Id);
        //This will gives you actors of above movie. 
        var actrs = mvz.Actors.ToList();
    
        var vm = new MoviesViewModel()
        {
            mvz = mvz,
            actrs = actrs
        };
    
        if (vm == null)
        {
            return Content("Nothing Found!");
        }
        //This view model return your both of movie and its actors.
        //Capture both in your model and render in your view.
        return View(vm);
    }

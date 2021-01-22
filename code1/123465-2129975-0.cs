    [AcceptVerbs(HttpVerbs.Post) , Authorize] 
    public ActionResult Create([Bind(Exclude="problem_id")] Problem inProblem) 
    { 
        try 
        { 
            // TODO: Add insert logic here 
            Models.User user = getUser(User.Identity.Name); 
            if (user != null) 
            { 
                inProblem.user_id = user.user_id; 
            } 
            _entities.AddToProblemSet(inProblem); 
            _entities.SaveChanges(); 
     
            return RedirectToAction("Index"); 
        } 
        catch 
        { 
	        this.ViewData["Books"] = new SelectList(_entities.BookSet.ToList(), "book_id", "Title"); 
            // ViewData["book_id"] with example above.
            return View(); 
        } 
    } 

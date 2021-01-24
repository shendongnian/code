    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CommentaarText, Tijdstip")] int id, IFormCollection collection) //Bind = protect from overposting
        {
             if(ModelState.IsValid)
             {
                 //If it is valid, do all your business logic, like creating a new entry.
             }
             else
             {
                 //Handle it
                 return View();
             }
        }

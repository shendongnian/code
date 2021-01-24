    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CommentaarText, Tijdstip")] int id, CommentaarCreate_VM viewModel, IFormCollection collection) //Bind = protect from overposting
        {
            try
            {
              //If incoming string is null or empty
                if (string.IsNullOrEmpty(collection["Commentaar"]))
                {
                    return View(viewModel);
                }
    //This always returns true. It really shouldn't, because otherwise I wouldn't need that earlier check. 
    //If the model isn't valid in the View, this one should be false, right?
                if (ModelState.IsValid)
                {
                    // Creating  object to POST
                    //.....
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

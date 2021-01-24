    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentaarCreate_VM viewmodel)
        {
              if(ModelState.IsValid)
              {
                   //It is valid
                   //All your logic
              }
              else
              {
                   //Not valid
                   return View(Viewmodel model)
              }         
        }

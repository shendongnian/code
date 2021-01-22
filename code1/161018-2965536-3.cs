       public ActionResult JobsView( JobsViewModel model )
       {
            model.JobList = db.Jobs.Select( j => new SelectListItem 
                                                 {
                                                      Text = j.Name,
                                                      Value = j.ID.ToString()
                                                 });
            ...
            return View( model );
       }

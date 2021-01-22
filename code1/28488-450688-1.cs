        [AcceptVerbs( HttpVerbs.Post )]
        [Authorization( Roles = "SuperUser, EditEvent, EditMasterEvent")]
        public ActionResult Save( FormCollection form )
        {
             using (DataContext context = ...)
             {
                  Event evt = new Event();
                  if (!TryUpdateModel( evt, new [] { "EventName", "CategoryID", ... }))
                  {
                      this.ModelState.AddModelError( "Could not update model..." );
                      return View("New");  // back to display errors...
                  }
                  context.InsertOnSubmit( evt );
                  context.SubmitChanges();
                  return RedirectToAction( "Show", "Event", new { id = evt.EventID } );
             }
        }

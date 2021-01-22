     [ActionName("People")]
     [AcceptVerbs( HttpVerbs.Get )]
     public ActionResult PeopleDisplay( SearchModel filter )
     {
         return People( filter );
     }
     [AcceptVerbs( HttpVerbs.Post)]
     [ValidateAntiForgeryToken]
     public ActionResult People( SearchModel filter )
     {
         ....
     }

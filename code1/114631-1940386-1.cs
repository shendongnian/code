     [AcceptVerbs( HttpVerbs.Post )]
     [ActionName( "MyAction" )]
     public ActionResult MyPostAction( string from, string to, ... )
     {
         // you may be able to simply reuse the RouteValueDictionary, but may
         // also need some transformations...
         return RedirectToAction( "MyAction", new { from = from, to = to, ... } );
     }
     [AcceptVerbs( HttpVerbs.Get )]
     public ActionResult MyAction( string from, string to, ... )
     {
         ...
     }

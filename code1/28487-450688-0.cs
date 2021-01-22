        [AcceptVerbs( HttpVerbs.Get )]
        [Authorization( Roles = "SuperUser, EditEvent, EditMasterEvent")]
        public ActionResult New()
        {
            ViewData["Title"] = "New Event";
            if (this.IsMasterEditAllowed())
            {
                ViewData["ShowNewMaster"] = "true";
            }
            return View();
        }

    [ActionName("ControlTemp"), AcceptVerbs(HttpVerbs.Post)] 
            public ActionResult ControlTemp(string URL) 
            { 
                if(this.ControllerContext.IsChildAction)
                     return  ControlTemp()//Get action method
                ... 
                return PartialView("ControlTemp"); 
            } 

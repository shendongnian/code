        [Authorize(Roles = "Administrator")]
        public ViewResult Function([FromQuery] int? Id)
        {
            return View();
        }
Or otherwise if you want to show this view for all roles except one then do this way.
        [Authorize]
        public ActionResult Function([FromQuery] int? Id)
        {
            if (!User.HasRole("GenericRole"))
                return new HttpUnauthorizedResult();
            return View();
        }

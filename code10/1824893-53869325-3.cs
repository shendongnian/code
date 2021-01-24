        [Authorize]
        public ActionResult Function([FromQuery] int? Id)
        {
            if (!User.HasRole("GenericRole"))
                return new HttpUnauthorizedResult();
            return View();
        }

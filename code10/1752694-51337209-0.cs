        [Authorize(Users = @"pcName\user")]
        public ActionResult ForAdministrator()
        {
            return View();
        }
        // Authorization with windows authentication (user)
        [Authorize(Users = @"pcName\user")]
        public ActionResult ForUser()
        {
            return View();
        }

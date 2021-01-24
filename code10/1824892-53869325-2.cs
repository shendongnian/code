        [Authorize(Roles = "Administrator")]
        public ViewResult Function([FromQuery] int? Id)
        {
            return View();
        }

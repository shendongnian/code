    [Authorize(Roles = "user or group")]
        public IActionResult UpdateGrade()
        {
            //update grade  here
            return View();
        }

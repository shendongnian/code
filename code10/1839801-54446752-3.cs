        public IActionResult Login(string origin)
        {
            //save original url
            ViewBag.Origin = origin; 
            return View();
        }
         
        //get the original url from hide input
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //if (login successfull)
            //{
                return Redirect(model.Origin);
            //}
            // else
            //{
                return View(model);
            //}
        }

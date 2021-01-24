         public ActionResult Login()
         {           
             return View();    
         }
    
        [HttpPost]                         
        public ActionResult Login(LoginModel model)
        {
           //Here check the Login Id and Password 
            return View(); 
        }

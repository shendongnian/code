    public ActionResult Step1()
    {
       User user = new User();
       return View(user);
    }
 
 
     [Post]
      public ActionResult Step1(User user)
        {
           //perform business validation
            RedirectToAction<UserController>(u => Step2(user)); 
    
        }

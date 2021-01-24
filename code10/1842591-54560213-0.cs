     [HttpGet]
     public ActionResult Create()
     {   
         var userList =  _dbContext.Users.ToList();
         ViewBag.OwnerSelectList = new SelectList(userList, "ID", "UserName");
         return View();
     }

    public JsonResult GetAllUsers() 
    { 
       List<User> Users = Common.Framework.Persistence.PersistSvr<Business.Entity.User>
                         .GetAll().ToList(); 
      return Json(Users); 
    }

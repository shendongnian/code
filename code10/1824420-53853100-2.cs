    public JsonResult IsUserNameExist(string UserName, int? Id)
    {
         var IsUserNameExists = db.Users.Any(x => x.UserName== UserName && x.Id != Id);
         return Json(!IsUserNameExists, JsonRequestBehavior.AllowGet);
    }

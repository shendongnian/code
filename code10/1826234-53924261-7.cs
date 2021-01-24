    public JsonResult IsUserAlreadyExists(string Email, int? Id)
    {
         var isUserAlreadyExists = db.Users.Any(x => x.Email== Email && x.Id != Id);
         return Json(!isUserAlreadyExists, JsonRequestBehavior.AllowGet);
    }

    public JsonResult IsEmailAlreadyExists(string Email, int? Id)
    {
         var isEmailAlreadyExists = db.Users.Any(x => x.Email== Email && x.Id != Id);
         return Json(!isEmailAlreadyExists, JsonRequestBehavior.AllowGet);
    }

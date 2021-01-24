    public JsonResult IsEmailAlreadyExists(string Email, int? Id)
    {
         var isEmailAlreadyExists = userRepo.IsUserAlreadyExistsByEmail(Email,Id);
         return Json(!isEmailAlreadyExists, JsonRequestBehavior.AllowGet);
    }

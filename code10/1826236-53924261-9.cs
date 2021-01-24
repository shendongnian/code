    public JsonResult IsUserAlreadyExists(string Email, int? Id)
    {
         var isUserAlreadyExists = userRepo.IsUserAlreadyExistsByEmail(Email,Id);
         return Json(!isUserAlreadyExists, JsonRequestBehavior.AllowGet);
    }

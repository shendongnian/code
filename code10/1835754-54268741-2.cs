    public ActionResult User(int id)
    {
        var user = userRepository.GetUserById(id);
        return Json(user, JsonRequestBehavior.AllowGet);
    }

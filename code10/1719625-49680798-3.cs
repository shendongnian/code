    public ActionResult LogOut()
    {
        if (Request.IsAjaxRequest())
        {
            FormsAuthentication.SignOut();
            TempData.Clear();
            Session.Abandon();
            getDB.Close();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    
        return Json(false, JsonRequestBehavior.AllowGet);
    }

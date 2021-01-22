    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult EditRole(string usernameID, FormCollection formValues)
    {
        string choosenRole = Request.Form["Roles"];                               
        System.Web.Security.Roles.AddUserToRole(usernameID, choosenRole);
        return RedirectToAction("Index");
    }

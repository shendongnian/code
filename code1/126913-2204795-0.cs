    <%=Html.TextBox("UserName", TempData["UserName"])%>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult SomeAction(string UserName)
        {
            TempData["UserName"] = UserName;
            // Do your validation
            var validator = new UserValidator();
            var results = validator.Validate(user);
            results.AddToModelState(ModelState, "");
            if (!ModelState.IsValid) 
            {
                return View("SignUp", user);
            }
            //return some view
        }

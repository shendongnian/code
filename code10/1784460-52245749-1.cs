    public ActionResult NewRole()
        {
            var applicationRoles = applicationRolesData.GetAllApplicationRoles().Select(x =>
                        new SelectListItem
                            {
                                Value = x.UserRoleId.ToString(),
                                Text = x.UserRole
                            });;
            ApplicationRolesViewModel ardlvm = new ApplicationRolesViewModel();
            ardlvm.Roles = new SelectList(applicationRoles , "Value", "Text")
            return View("~/Views/Users/Modals/AddRole.cshtml", ardlvm);
        }

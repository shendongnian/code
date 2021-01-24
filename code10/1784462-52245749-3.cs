    public ActionResult NewRole()
        {
            var roleData = new List<SelectListItem>();
            applicationRolesData.GetAllApplicationRoles().Foreach(x =>
                       roleData.Add( new SelectListItem
                            {
                                Value = x.RoleId.ToString(),
                                Text = x.ApplicationRoleName
                            });
           );
            ApplicationRolesViewModel ardlvm = new ApplicationRolesViewModel();
            ardlvm.Roles = new SelectList(roleData , "Value", "Text")
            return View("~/Views/Users/Modals/AddRole.cshtml", ardlvm);
        }

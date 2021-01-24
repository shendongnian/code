    Html.DropDownFor(x => x.SelectedItem, Model.DepartmentList)
    // then something like
    public async Task<ActionResult> Login(LoginViewModel lmodel, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(lmodel);
        }
        ApplicationUser user = new ApplicationUser() {
            UserName = lmodel.username,
            Password = lmodel.password,
            //... other AspNetUser values assigned?
            //...,
            Department_Id = lmodel.selectedDepartment
        }
        var result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded) {
           await SignInAsync(user, isPersistent: false);
           return RedirectToAction("Index", "Home");
        }        
    }  

    [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
    
                try
                {
                    var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
    
                    switch (result)
                    {
                        case SignInStatus.Success:
     
                            var user = User.Identity;
                            try
                            {
                                ApplicationDbContext context = new ApplicationDbContext();
    
                                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    
                                string userId = UserManager.FindByName(model.UserName)?.Id;
    
                                var s = UserManager.GetRoles(userId);
                                 // db is EF context and UsersViews is user SQL View
                                var u = db.UsersViews.First(x => x.Id == userId);
    
                                var serializeModel = new CustomPrincipalSerializeModel
                                {
                                    Id = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    MiddleName = u.MiddleName,
                                    RoleName = u.RoleName,
                                    RoleNameCode = u.RoleNameCode
                                };
                                JavaScriptSerializer serializer = new JavaScriptSerializer();
                                string userData = serializer.Serialize(serializeModel);
                                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, userData);
                                string encTicket = FormsAuthentication.Encrypt(authTicket);
                                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                                Response.Cookies.Add(faCookie);
    
                                return RedirectToAction("Index", "Home");
                                
                            }
                            catch (Exception ex)
                            {
                              
                                return View("Lockout");
                            }
                        case SignInStatus.LockedOut:
                            return View("Lockout");
                        case SignInStatus.RequiresVerification:
                            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                        case SignInStatus.Failure:
                        default:
                            ModelState.AddModelError("", "Invalid login attempt.");
                            return View(model);
                    }
                }
                catch (Exception ex)
                {
    
                    throw;
                }
    
            }

     public async Task<String> Login(string userName, string password, bool rememberMe, int AgencyId)
        {
            var user = await UserManager.FindByEmailAsync(userName);
            if (AgencyId == user.AgencyId)
            {
                var loginrole = IdentityHelper.GetRoleName(userName);
                if (loginrole=="Administrator")
                {
                    var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            return "Success";
                       
                        case SignInStatus.Failure:
                            return "Invalid email or password";
                        default:
                            return "Invalid email or password";
                    }
                }
                else
                {
                    var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: true);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            return "Success";
                        case SignInStatus.LockedOut:
                            UserManager.SetLockoutEndDate(user.Id, new DateTime(9999, 12, 30));
                            return "Your account has been locked, Please contact administrator.";
                        case SignInStatus.Failure:
                            return "Invalid email or password";
                        default:
                            return "Invalid email or password";
                    }
                }
               
            }
            else
            {
                return "Invalid Agency";
            }
        }

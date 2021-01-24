       protected void IdentitySignin(IUserModel userModel, string providerKey = null, bool isPersistent = true)
            {
                var claims                                                         = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, userModel.UserName),
                    new Claim("UserContext", userModel.ToString())
                };
                var identity                                                       = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent                                                   = isPersistent,
                    ExpiresUtc                                                     = DateTime.UtcNow.AddDays(7)
                }, identity);
            }

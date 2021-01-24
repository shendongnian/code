    if (_user == null){
                    var user = new ApplicationUser
                    {
                        UserName = "Administrator",
                        Email = "youremail",
                        RoleId = 1
                    };
                    var result = await UserManager.CreateAsync(user,"yourpassword");
                    UserManager.AddToRole(user.Id, "Admin");
                }

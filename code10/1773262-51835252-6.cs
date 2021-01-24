    public async Task Seed()
            {
                try
                {
                    if (RoleManager.Roles.ToList().Count == 0)
                        foreach (string role in typeof(RoleConst).GetConstValue<string>())
                            await RoleManager.CreateAsync(new RoleEntity { Name = role.ToString() });
    
                    if (UserManager.Users.ToList().Count == 0)
                    {
                        UserEntity entity = new UserEntity
                        {
                            Email = "y",
                            Active = true,
                            Deleted = false,
                            EmailConfirmed = true,
                            Created = DateTime.UtcNow,
                            Modified = DateTime.UtcNow,
                            Name = "y",
                            UserName = "x"
                        };
                        await UserManager.CreateAsync(entity, "fg@123");
                        await UserManager.AddToRoleAsync(entity, RoleConst.Admin);
                        //Send Invitation email to Admin in the Production.
                    }
                    if(DapperLanguage.All().ToList().Count()==0)
                    {
                        await DapperLanguage.AddAsync(new Language
                        {
                            Id = Guid.NewGuid(),
                            Code = LanguageConst.English,
                            Name = "English"
                        });
                        await DapperLanguage.AddAsync(new Language
                        {
                            Id = Guid.NewGuid(),
                            Code = LanguageConst.Arabic,
                            Name = "Arabic"
                        });
                    }
                }
                catch (Exception ex)
                {
                    LogManager.LogError(JsonConvert.SerializeObject(new { class_name = this.GetType().Name, exception = ex }));
                }
            }

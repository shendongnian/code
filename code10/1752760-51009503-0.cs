     public async Task<IEnumerable<AccountViewModel>> GetUserList()
            {
                var userList = await (from user in _context.Users
                                      select new
                                      {
                                          UserId = user.Id,
                                          Username = user.UserName,
                                          user.Email,
                                          user.EmailConfirmed,
                                          RoleNames = (from userRole in user.Roles //[AspNetUserRoles]
                                                       join role in _context.Roles //[AspNetRoles]//
                                                       on userRole.RoleId
                                                       equals role.Id
                                                       select role.Name).ToList()
                                      }).ToListAsync();
    
                var userListVm = userList.Select(p => new AccountViewModel
                {
                    UserId = p.UserId,
                    UserName = p.Username,
                    Email = p.Email,
                    Roles = string.Join(",", p.RoleNames),
                    EmailConfirmed = p.EmailConfirmed.ToString()
                });
    
                return userListVm;
            }

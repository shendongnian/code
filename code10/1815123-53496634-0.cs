        [HttpGet("UserList")]
        public IEnumerable<User> UserList()
        {
            return _applicationUserManager.Users.ToList();
        }
     [HttpGet("Roles")]
        public async Task<IActionResult> Role()
        {
            List<UserRoleViewModel> URVM = new List<UserRoleViewModel>();
            foreach (var item in UserList())
            {
                var users = await _applicationUserManager.FindUserById(item.Id);
                var roles = await _applicationUserManager.GetRolesAsync(users);
                var roleName = await _applicationRoleManager.FindRoleByNameList(roles[0]);
                URVM.Add(new UserRoleViewModel
                {
                    Id = users.Id,
                    Email = users.Email,
                    BirthDate = users.BirthDate,
                    CreatedDateTime = users.CreatedDateTime,
                    FirstName = users.FirstName,
                    IsActive = users.IsActive,
                    PhoneNmuberConfirmed=users.PhoneNumberConfirmed,
                    IsEmailPublic = users.IsEmailPublic,
                    LastName = users.LastName,
                    TwoFactorEnabled = users.TwoFactorEnabled,
                    EmailConfirmed = users.EmailConfirmed,
                    LockoutEnabled = users.LockoutEnabled,
                    LastVisitDateTime = users.LastVisitDateTime,
                    Location = users.Location,
                    PhotoFileName = users.PhotoFileName,
                    RoleLevel = roleName.RoleLevel,
                    Description = roleName.Description,
                    roleId = roleName.Id
                });
            }
            return Ok(URVM);
        }

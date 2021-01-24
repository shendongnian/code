    public IActionResult AddAdmin()
    {
        var allUsers = (from u in _dbContext.Users
                        select new UserViewModel
                     {
                         UserName = u.UserName,
                         Email = u.Email,
                         Id = u.Id
                         
                     }).ToList();
        foreach (var item in allUsers)
        {
            var roleId = _dbContext.UserRoles.Where(x => x.UserId == item.Id).FirstOrDefault();
            item.Role = _dbContext.Roles.Where(x => x.Id == roleId.RoleId).FirstOrDefault().Name;
        }
        return View(allUsers);
    }

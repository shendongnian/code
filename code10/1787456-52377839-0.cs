    using (var context = new ApplicationDbContext())
    {
        var users = from u in context.Users
            where u.Roles.Any(r => r.Role.Name == "RoleName")
            select u;
    
        // ViewBag.Users = new SelectList(users, "Id", "UserName");
        ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();
    }

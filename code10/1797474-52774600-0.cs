            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var r1 = User.IsInRole("User");
            var r2 = User.IsInRole("user");
            var r3 = await _userManager.IsInRoleAsync(user, "user");

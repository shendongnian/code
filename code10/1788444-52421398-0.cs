                    var roleName = Guid.NewGuid().ToString();                
                var r1 = User.IsInRole(roleName);
                var user = await _userManager.GetUserAsync(User);
                var role = await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
                await _userManager.AddToRoleAsync(user, roleName);
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                var claims = claimsPrincipal.Claims.ToList();
                
                User.AddIdentity(new ClaimsIdentity(new List<Claim>() { claims.FirstOrDefault(c => c.Value == roleName) }));
                var r3 = User.IsInRole(roleName);

    // Get User roles and add them to claims
                    var roles = await _userManager.GetRolesAsync(user);
                    AddRolesToClaims(claims, roles);
    // ===== Token =====
            private async Task<object> GenerateJwtToken(User user)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                };
    
                // Get User roles and add them to claims
                var roles = await _userManager.GetRolesAsync(user);
                AddRolesToClaims(claims, roles);
    
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
    
                var token = new JwtSecurityToken(
                    _configuration["JwtIssuer"],
                    _configuration["JwtIssuer"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );
    
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
    
    
            private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
            {
                foreach (var role in roles)
                {
                    var roleClaim = new Claim(ClaimTypes.Role, role);
                    claims.Add(roleClaim);
                }
            }

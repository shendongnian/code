        [AllowAnonymous]
        [HttpPost]
        [Route("api/acccount/token")]
        public async Task<IActionResult> Token([FromBody] Models.User loginUser)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(loginUser.UserName);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
                if (result.Succeeded)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                      _config["Tokens:Issuer"],
                      claims,
                      expires: DateTime.Now.AddMinutes(30),
                      signingCredentials: creds);
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }
            return base.Forbid();
        }

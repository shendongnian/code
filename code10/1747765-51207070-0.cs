     [HttpPost("GenerateToken")]
      public IActionResult GenerateToken(string emailid)
        {
       //DB verification for email\username\password goes here  
            if (emailid.Equals("abcd@gmail.com"))
            {
                var claimsdata = new[]
                {
                           new Claim("firstName", "FirstName"),
                           new Claim("LastName", "LasttName"),
                           new Claim("Email", "Email@email.com"),
                           new Claim(ClaimTypes.Email, "myemailid@email.com")
                        };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkeygoeshere"));
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "mysite.com",
                    audience: "mysite.com",
                    expires: DateTime.Now.AddMinutes(20),
                    claims: claimsdata,
                    signingCredentials: signInCred
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { jwt = tokenString });
            }
            // return BadRequest("Could not verify the user");
            return Unauthorized();
        }

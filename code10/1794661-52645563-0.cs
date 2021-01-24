     [HttpPost("Token")]
     public IActionResult Token(string userid)
    {
        if ((!string.IsNullOrEmpty(userid)))
        {
            var user = webuserprovider.GetWebUser(userid);
            // validate for 0 records 
            if (user.Count() > 0)
            {
               // if user return 1 row
               var claimsdata = new[]
               { 
                     new  Claim("subject","custom claims"),                     
               };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey"));
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                      users:{ "id": user.First().UserID},
                      issuer: "mysite.com",
                      audience: "yoursite.com",
                      expires: DateTime.Now.AddMinutes(3),
                      claims: claimsdata,                      
                    signingCredentials: signInCred
                    );
                   //custom claims as per  requirements
                    var jsonu = new { id = user.First().UserID };
                    token.Payload["user"] = jsonu;
                   //End of custom claims
                  var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                  return Ok(new {jwt});
               // return Ok( new JwtSecurityTokenHandler().WriteToken(token) );
            }
            else
            {// return BadRequest(new { message = "UserID does not exist" }); }
             // return BadRequest("Could not verify user");
                return NotFound();
            }
        }
        return Unauthorized();
    }
    }
    }

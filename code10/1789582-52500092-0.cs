     [HttpPost("validateToken")]
            public string ValidateToken ([FromBody] string token)
            {
                var jwthandler = new JwtSecurityTokenHandler();
                var jwttoken = jwthandler.ReadJwtToken(token);
                var expDate = jwttoken.ValidTo;
                if (expDate < DateTime.UtcNow.AddMinutes(3))
                {
                    return ("invalid");
    
                }
                else
                {
                    return("valid");
                }
            }
       

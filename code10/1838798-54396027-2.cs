       var claims = new List<Claim>
        {
            new Claim(ClaimTypes.WindowsAccountName, this.User.Identity.Name)
        };
        Claim userIdClaim = new Claim("UserId", "12345");
        claims.Add(userIdClaim);
        //Avoid Replay attack
        claims.Add(new Claim(ClaimTypes.GivenName, "User GivenName"));
        claims.Add(new Claim(ClaimTypes.Surname, "UserSurname"));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        string[] roles = "Role1,Role2,Role23".Split(",");
        foreach (string role in roles)
        {
            claims.Add(new Claim(role, ""));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryVerySecretKey"));
        var key1 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASEFRFDDWSDRGYHF")); 
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var encryptingCreds = new EncryptingCredentials(key1, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
        var handler = new JwtSecurityTokenHandler();
        var t = handler.CreateJwtSecurityToken();
        var token = handler.CreateJwtSecurityToken("http://localhost:61768/", "http://localhost:61768/"
            , new ClaimsIdentity(claims)
            , expires: DateTime.Now.AddMinutes(1)
            , signingCredentials: creds
            , encryptingCredentials :encryptingCreds
            , notBefore:DateTime.Now
            ,  issuedAt:DateTime.Now);
        return new JwtSecurityTokenHandler().WriteToken(token);

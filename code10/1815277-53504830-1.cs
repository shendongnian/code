    var claims = new Claim[] { new SomeClaimes() };
    var scKey = Encoding.UTF8.GetBytes("SOME KEY");
    var ecKeyTemp = Encoding.UTF8.GetBytes("SOME OTHER KEY");
    
    // Note that the ecKey should have 256 / 8 length:
    byte[] ecKey = new byte[256 / 8];
    Array.Copy(ecKeyTemp, ecKey, 256 / 8);
    
    var tokenDescriptor = new SecurityTokenDescriptor {
        Subject = new ClaimsIdentity(claims),
        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                scKey),
                SecurityAlgorithms.HmacSha512),
        EncryptingCredentials = new EncryptingCredentials(
            new SymmetricSecurityKey(
                ecKey),
                SecurityAlgorithms.Aes256KW,
                SecurityAlgorithms.Aes256CbcHmacSha512), 
        Issuer = "My Jwt Issuer",
        Audience = "My Jwt Audience",
        IssuedAt = DateTime.UtcNow,
        Expires = DateTime.Now.AddDays(7),
    };
    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
    var jwt = tokenHandler.WriteToken(token);

    private string BuildToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
          _jwtOptions.Issuer, // some issuer, e.x. you can specify your localhost
          _jwtOptions.Issuer,
          expires: DateTime.Now.AddMinutes(_jwtOptions.Expires),  // int value
          signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

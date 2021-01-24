    public AuthenticationDTO DecodeToken(String Input)
    {
        var key = Encoding.ASCII.GetBytes(HostConfig.SecurityKey);
        var handler = new JwtSecurityTokenHandler();
        var tokenSecure = handler.ReadToken(Input) as SecurityToken;
        var validations = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
        var claims = handler.ValidateToken(Input, validations, out tokenSecure);
        var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
        if (principal is ClaimsPrincipal claims)
        {
             return new ApplicationDTO
                 {
                     Id = claims.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? "",
                     UserName = claims.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value ?? "",
                 };
        }
        return null;
    }

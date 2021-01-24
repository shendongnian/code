    public class TokenHelper
    {
        public const string Issuer = "http://www.mywebsite.com/myapp";
        public const string Audience = "http://www.mywebsite.com/myapp";
        // This should not be hardcoded!
        public const string Secret = "My_super_secret";
        public AccessToken CreateAccessToken(LoginInfo loginInfo)
        {
            // Set expiration time of 5 minutes.
            DateTime expires = DateTime.UtcNow.AddMinutes(5);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginInfo.UserId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            // Add custom claims, rolepermissions
            if (loginInfo.Permissions != null && loginInfo.Permissions.Any())
                loginInfo.Permissions.foreach(p => claims.Add(new Claim("Permission", p)));
            if (loginInfo.IsUser)
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            if (loginInfo.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: expires,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
                        SecurityAlgorithms.HmacSha256
                    )
                );
            return new AccessToken
            {
                ServerTime = DateTime.UtcNow.ToString("yyyyMMddTHH:mm:ssZ"),
                Expires = expires.ToString("yyyyMMddTHH:mm:ssZ"),
                Bearer = new JwtSecurityTokenHandler().WriteToken(token)
             };
        }
    }

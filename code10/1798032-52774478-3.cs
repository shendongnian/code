    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
    public sealed class JwtToken
    {
        private JwtSecurityToken Token;
        internal JwtToken(JwtSecurityToken token)
        {
            this.Token = token;
        }
        public DateTime ValidTo => Token.ValidTo;
        public string Value => new JwtSecurityTokenHandler().WriteToken(this.Token);
    }
    public class JwtTokenBuilder
    {
        private SecurityKey SecurityKey = null;
        private string Subject = "";
        private string Issuer = "";
        private string Audience = "";
        private Dictionary<string, string> Claims = new Dictionary<string, string>();
        private int ExpiryInMinutes = 5;
        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.SecurityKey = securityKey;
            return this;
        }
        public JwtTokenBuilder AddSubject(string subject)
        {
            this.Subject = subject;
            return this;
        }
        public JwtTokenBuilder AddIssuer(string issuer)
        {
            this.Issuer = issuer;
            return this;
        }
        public JwtTokenBuilder AddAudience(string audience)
        {
            this.Audience = audience;
            return this;
        }
        public JwtTokenBuilder AddClaim(string type, string value)
        {
            this.Claims.Add(type, value);
            return this;
        }
        public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        {
            this.Claims.Union(claims);
            return this;
        }
        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            this.ExpiryInMinutes = expiryInMinutes;
            return this;
        }
        public JwtToken Build()
        {
            EnsureArguments();
            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Sub, this.Subject),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(this.Claims.Select(item => new Claim(item.Key, item.Value)));
            var token = new JwtSecurityToken(
                              issuer: this.Issuer,
                              audience: this.Audience,
                              claims: claims,
                              expires: DateTime.UtcNow.AddMinutes(ExpiryInMinutes),
                              signingCredentials: new SigningCredentials(
                                                        this.SecurityKey,
                                                        SecurityAlgorithms.HmacSha256));
            return new JwtToken(token);
        }
        #region Privates
        private void EnsureArguments()
        {
            if (this.SecurityKey == null)
                throw new ArgumentNullException("Security Key");
            if (string.IsNullOrEmpty(this.Subject))
                throw new ArgumentNullException("Subject");
            if (string.IsNullOrEmpty(this.Issuer))
                throw new ArgumentNullException("Issuer");
            if (string.IsNullOrEmpty(this.Audience))
                throw new ArgumentNullException("Audience");
        }
        #endregion
    }

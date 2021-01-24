    public class CustomSecureDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            var claims = new List<Claim>();
            //Custom claim
            claims.Add(new Claim("HairCount", "46"));
            data.Identity.AddClaims(claims);
            string audienceId = AzureADConstants.GraphResourceId;
            Guid guidClientId;
            bool isValidAudience = Guid.TryParse(AzureADConstants.ClientId, out guidClientId);
            if (!isValidAudience)
            {
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");
            }
            
            var keyByteArray = TextEncodings.Base64Url.Decode(AzureADConstants.AppKey);
            var securityKey = new SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256Signature);
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            string _issuer = AzureADConstants.Authority;
            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
        public AuthenticationTicket Unprotect(string protectedText)
        {
            if (string.IsNullOrWhiteSpace(protectedText))
            {
                throw new ArgumentNullException("protectedText");
            }
            
            var keyByteArray = TextEncodings.Base64Url.Decode(AzureADConstants.AppKey);
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256Signature);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadToken(protectedText);
            string rawToken = ((JwtSecurityToken)securityToken).RawData;
            string audienceId = AzureADConstants.GraphResourceId;
            var validationParams = new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidAudience = audienceId,
                ValidIssuer = audienceId,
                ValidateIssuer = false,
                ValidateAudience = false,
                TokenDecryptionKey = securityKey,
                IssuerSigningKey = securityKey
            };
            SecurityToken validatedToken;
            var principal = handler.ValidateToken(rawToken, validationParams, out validatedToken);
            var identity = principal.Identities;
            return new AuthenticationTicket(identity.First(), new AuthenticationProperties());
        }
    }

        public static bool ValidateToken(string authToken) // Retrieve token from request header
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = this.GetValidationParameters();
            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
            return true;
        }
        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningToken = new System.ServiceModel.Security.Tokens.BinarySecretSecurityToken(symmetricKey), //Key used for token generation
                ValidIssuer = issuerName,
                ValidAudience = allowedAudience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true
            };
        }

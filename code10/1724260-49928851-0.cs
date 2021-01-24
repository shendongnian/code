        public class JwtTokenService:IJwtTokenService
        {
            private readonly IDataSerializer<AuthenticationTicket> _ticketSerializer;
            private readonly IDataProtector _dataProtector;
        
            public JwtTokenService(IDataSerializer<AuthenticationTicket> serializer, IDataProtector protector)
            {
                _ticketSerializer = serializer;
                _dataProtector = protector;
            }
        
            public string UnprotectToken(string protectedText)
            {
                SecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(" ......... "));
                TokenValidationParameters tokenValidationParameters =
                    _getTokenValidationParameters();
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                AuthenticationTicket authTicket;
                string embeddedJwt;
                try
                {
                    // logic to deserialize token
                    // logic to validate token
                    // more logic... (algorithm,..)
                }
                catch (Exception)
                {
                    return null;
                }
                return embeddedJwt;
            }
        }

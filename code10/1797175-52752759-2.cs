    public class JwtTokenService : IOneTimeOnlyJwtTokenService
    {
        private readonly IConfiguration _config;
        public JwtTokenService(IConfiguration config )
        {
            _config = config;
           
        }
        /// <summary>
        /// Builds the token used for authentication
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<string> BuildToken(string userName,int? expireTime)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, userName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var sign= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiredAt = expireTime != null ?
                DateTime.UtcNow.AddHours((int)expireTime) :
                DateTime.Now.AddHours(int.Parse(_config["Jwt:ExpireTime"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims) ,
                Expires = expiredAt,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = sign,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token= tokenHandler.CreateToken(tokenDescriptor);
            var tokenString=tokenHandler.WriteToken(token);
            await this.RegisterToken(tokenString);
            return tokenString;
        }
        private async Task RegisterToken(string token) 
        {
            // register token 
        }
        public async Task<bool> HasBeenConsumed(string token) 
        {
            // check the state of token
        }
        public async Task InvalidateToken(string token) 
        {
             // persist the invalid state of token
        }
    }

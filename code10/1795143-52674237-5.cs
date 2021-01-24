    public class ValuesController : ControllerBase
    {
        [HttpGet("/api/values")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<string> Values()
        {
            return $"You have authorized access";
        }
        [HttpGet("/api/jwt")]
        public ActionResult<string> Jwt()
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this-is-the-secret"));
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { /* add claims */}),
                Issuer = "my-auth-server",
                Audience = "my-resource-server",
                SigningCredentials =
                    new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddDays(1)
            };
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.CreateToken(descriptor);
            return jwtHandler.WriteToken(token);
            // alternatively
            // return jwtHandler.CreateEncodedJwt(descriptor);
        }
    }      

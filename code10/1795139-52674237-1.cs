    public class ValuesController : ControllerBase
    {
        [HttpGet("/api/values")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<string>> Values()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("/api/jwt")]
        public ActionResult<string> Jwt()
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this-is-the-secret"));
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity("shaun"),
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

    public static class Auth
    {
        private static string salt = "jnyanendra_sethi"; // u can chose any key satisfying the length 
        private static int timeoutInMinute = 1;
        private static string _issuer = "http://localhost:5000";
        private static string _audience = "http://localhost:5000";
        //Generate Token
        public static string GenerateToken(Customer customer, List<SupplierInfo> lstSpplierInfo)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(salt));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            // var suppliers = any json string e.g. [{"SupplierId":1001,"SupplierName":"RateHawk"},{"SupplierId":1002,"SupplierName":"Hotelbeds"}]
            var suppliers = JsonConvert.SerializeObject(lstSpplierInfo);//"ur json object to store in claim";
            var claims = new List<Claim> {
               new Claim("CustomerName", customer.CustomerName),
               new Claim("Suppliers",suppliers )
           };
            var mytoken = new JwtSecurityToken(issuer: _issuer, audience: _audience,
                claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(timeoutInMinute), signingCredentials: credential);
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(mytoken);
            return tokenValue;
        }
        //Validate token
        public static void ValidateJwtToken(this IServiceCollection services)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(salt));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var tokenParam = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireSignedTokens = true,
                IssuerSigningKey = credential.Key,
                ClockSkew = TimeSpan.FromMinutes(timeoutInMinute)
            };
            services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = tokenParam;
                });
        }
    }
----------------
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        [HttpGet("Search")]
        public SearchReponse Search()// u can take search parameters for input
        {
            // based on apikey or username, call db for first time
            // get customername / supplierinfo from db
            Customer customer = new Customer() { CustomerId = "CUS001", CustomerName = "TestCust" };// dummy
            if (customer == null)
            {
                this.HttpContext.Response.StatusCode = 401;
                return new SearchReponse()
                {
                    ErrorInfo = new ErrorInfo()
                    {
                        Code = "0",
                        Description = "No Customer Found"
                    }
                };
            }
            string token = Auth.GenerateToken(customer, GetDummyDataToStoreInClaim());
            SearchReponse reponse = new SearchReponse()
            {
                GeneralInfo = new GeneralInfo()
                {
                    Token = token,
                    Duration = 0
                },
                Hotels = "Hotels Data",
            };
            return reponse;
        }
               
        [Authorize]
        [HttpGet("Get/{id}")]
        public ActionResult<string> Get(int id)
        {//// Getting the data stored in claim that required for further process
            var CustomerName = HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "CustomerName").Value;
            var strSuppliers = HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "Suppliers").Value;
            return CustomerName;
        }
    }

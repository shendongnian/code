    public class UserManager: IUserManager
    {
        ...other code here removed for simplicity
        public List<Claim> GetClaimsAsync(Models.User user)
        {
            var claims = new List<Claim>();             
           
            claims.Add(new Claim(JwtClaimTypes.PreferredUserName, user.USER_ID.ToString().Trim()));
            //This next line is pseudo coded and would need to be coded.
            claims.Add(new Claim("MyCalculatedIP", MyFunctionToGetUserIP().ToString().Trim()));
            return claims;
        }
        ...other code here removed for simplicity
    }

     This code I using to get the calims
    
     --------
          private readonly DatabaseContext _context;
          int user_id = 0;
          int Account_id = 0;
          List<string> roles;
        
        public TEMP_CON_Controller(DatabaseContext context,IHttpContextAccessor,httpContextAccessor)
        {
          _context = context;
          if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
          {
            var user = httpContextAccessor.HttpContext.User;
    
            this.user_id = int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
    
            IEnumerable<Claim> claims = user.Claims;
    
            var accId = claims.Where(x => x.Type == "AccountId").Select(c => c.Value).SingleOrDefault();
    
            if (!string.IsNullOrEmpty(accId))
              this.Account_id = Int32.Parse(accId);
    
            roles = claims.Where(x => x.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
    
            
          }
        }
    ​

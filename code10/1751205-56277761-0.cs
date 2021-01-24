     public class ClaimsLoader : IClaimsTransformation
    {        
        private IUserrolesRepository repository;
        public ClaimsLoader(IUserrolesRepository repo)
        {
            repository = repo;
        }
        public bool ifRoleExist(ClaimsPrincipal principal, string value)
        {
            var ci = (ClaimsIdentity)principal.Identity;
            var claim = principal.FindAll(ci.RoleClaimType);
            foreach (var c in claim)
            {
                if (c.Value == value)
                    return true;
            }
            return false;
        }
       
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
       {            
            var ci = (ClaimsIdentity)principal.Identity;
            List<Userrole> userroles = await repository.Userroles.Include(u => u.R).Include(u => u.U).Where(u => u.U.Uid==principal.Identity.Name.Substring(10)).ToListAsync();
           
            if (userroles!=null)                {
                    
                foreach (Userrole ur in userroles)
                {
                    Claim claim = new Claim(ci.RoleClaimType, ur.Rid); 
                    if (!ifRoleExist(principal, ur.Rid))                  
                    ci.AddClaim(claim);
                }
            }                     
            return await Task.FromResult(principal);   
        }
    }

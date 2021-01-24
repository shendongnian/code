    public class ClaimsTransformer : IClaimsTransformation
    {
        private IRepository _repository;
        private IHttpContextAccessor _httpContextAccessor;        
        private IMemoryCache _cache;
        public ClaimsTransformer(IRepository repository, IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;           
            _cache = cache;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
       {
            if (principal.Identity.IsAuthenticated)
            {
                var currentPrincipal = (ClaimsIdentity)principal.Identity;
                var ci = (ClaimsIdentity)principal.Identity;
                var cacheKey = ci.Name;
                if (_cache.TryGetValue(cacheKey, out List<Claim> claims))
                {
                    currentPrincipal.AddClaims(claims);
                }
                else
                {
                    claims = new List<Claim>();
                    var isUserMasterAdmin = await _repository.IsUserMasterAdmin(ci.Name);
                    if (isUserMasterAdmin)
                    {
                        var c = new Claim(ClaimTypes.Role, "MasterAdmin");
                        claims.Add(c);
                    }
                    var isUserDeptAdmin = await _repository.IsUserDeptAdmin(ci.Name);
                    if (isUserDeptAdmin)
                    {
                        var c = new Claim(ClaimTypes.Role, "DeptAdmin");
                        claims.Add(c);
                    }
                    
                    _cache.Set(cacheKey, claims);
                    currentPrincipal.AddClaims(claims);
                }                
            }
            return await Task.FromResult(principal);
        }
    }

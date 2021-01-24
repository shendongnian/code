          private readonly IHttpContextAccessor _httpContextAccessor;    
          private readonly ISession _session;    
          public SessionManager(IHttpContextAccessor httpContextAccessor)    
          {    
                 _httpContextAccessor = httpContextAccessor;    
                 _session = _httpContextAccessor.HttpContext.Session;    
           }  

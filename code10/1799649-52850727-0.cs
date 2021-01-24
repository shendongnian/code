    private readonly SomeTenantsDbContext _context;
    privat readonly IActionContextAccessor _accessor;
    
    public TenantProvider(SomeTenantsDbContext context, IActionContextAccessor accessor )
    {
        _context = context;
        _accessor = accessor;
    }
    
    public void DoStuuff()
    {    
        var alias = _accessor?.ActionContext?.RouteData?.Values["tenant"]?.ToString();
        if(alias != null)
        {
            var tenantId = _context.Tenants.FirstOrDefault( t => t.Alias == alias)?.Id;
            // Do something with tenant id
        }
    }

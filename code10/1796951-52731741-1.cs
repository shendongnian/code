    public class CurrentTenantService : ICurrentTenantService
    {
      public Tenant GetCurrentTenant()
       {
          string currentUrl = HttpContext.Current.Url; //make sure to get only the base URL here
          return TenantDbContext.Tenants.FirstOrDefault(t=>t.Url == url); //TenantDbContext should be a class that has the Tenant entity
       }
    }

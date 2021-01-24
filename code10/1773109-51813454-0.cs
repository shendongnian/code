    interface ITenant
    {
        int TenantId { get; set; }
    }
    public class TenantUser : IUser, ITenant
    { ... }

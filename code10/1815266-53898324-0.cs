    public class User
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Tenant TenantDetails {get;set;}
    }

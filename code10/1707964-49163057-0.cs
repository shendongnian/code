        public class Property
        {
            public int PropertyId { get; set; }
            public int TenantId { get; set; }
            public int LandlordId { get; set; }
            public User Tenant { get; set; }
            public User Landlord { get; set; }
        }

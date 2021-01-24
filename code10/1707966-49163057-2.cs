        public class Property
        {
            public int PropertyId { get; set; }
            public int TenantId { get; set; }
            public int LandlordId { get; set; }
            public Tenant Tenant { get; set; }
            public Landlord Landlord { get; set; }
        }

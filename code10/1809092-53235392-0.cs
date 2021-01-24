    public class CustomClaim
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
    public class RoleClaimModel
    {
        public ApplicationRole Role { get; set; }
        public List<CustomClaim> ClaimList { get; set; }
    }

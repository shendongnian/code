    public partial class AspNetPolicy
    {
        public AspNetPolicy()
        {
            AspNetPolicyRequirement = new HashSet<AspNetPolicyRequirement>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool Enabled { get; set; } = true;
        [InverseProperty("AspNetPolicy")]
        public ICollection<AspNetPolicyRequirement> AspNetPolicyRequirement { get; set; }
    }
    public partial class AspNetPolicyRequirement
    {
        public int Id { get; set; }
        public int AspNetPolicyId { get; set; }
        public RequirementType RequirementType { get; set; }
        [Required]
        [StringLength(150)]
        public string RequirementName { get; set; }
        [Required]
        public bool Enabled { get; set; } = true;
        [ForeignKey("AspNetPolicyId")]
        [InverseProperty("AspNetPolicyRequirement")]
        public AspNetPolicy AspNetPolicy { get; set; }
    }
    public enum RequirementType
    {
        Custom = 0,
        Claim = 1,
        Role = 2,
        UserName = 3,
        AuthenticatedUser = 4,
        Assertion = 5,
    }

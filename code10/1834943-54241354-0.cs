    public class OrganisationInfo
    {
        [Key]
        public int OrgID { get; set; }
        public virtual List<OrgOwners> OrgOwners { get; set; } 
    }
    public class OrgOwners
    {
        [Key]
        public int OrgOwnerID { get; set; }
        public int OrgID { get; set; }
        public int? OrgRefID { get; set; }
        [ForeignKey("OrgRefID")]
        public virtual OrganisationInfo Organisation { get; set; } 
    }
    modelBuilder.Entity<OrganisationInfo>()
                        .HasMany(e => e.OrgOwners)
                        .WithRequired() 
                        .HasForeignKey(e => e.OrgID); 

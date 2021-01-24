    public int OrgID { get; set; } //Suppose to be a ForeignKey for (OrganisationInfo OrgOwners List)
    
    [ForeignKey("OrgID")]
    [InverseProperty("OrgOwners")]
    public virtual OrganisationInfo OwnerOrganization { get; set; }

    [Key]
    public int Id{ get; set; }
    [ForeignKey("Organization")]
    public int? OrganizationId { get; set; }
    public virtual Organization Organization { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string CaseComment { get; set; }
	modelBuilder.Entity<IdentityUserClaim>()
        .Property(b => b.ClaimType)
        .HasColumnType("nvarchar(MAX)")
        .HasMaxLength(null);

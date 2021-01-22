    public enum EnumStatus
    {
        [Display(Name = "Active", ShortName = "Act")]
        Active,
        [Display(Name = "Archived", ShortName = "Arc")]
        Archived,
    }
    ...
    public override void Configure(EntityTypeBuilder<MyEfEntity> b)
    {
        ...
        b.Property(x => x.EnumStatus).HasConversion<MyShortEnumsConverter>();
    }

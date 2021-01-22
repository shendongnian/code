    public enum EnumStatus
    {
        [Short("act")]
        Active,
        [Short("arc")]
        Archived,
    }
    ...
    public override void Configure(EntityTypeBuilder<MyEfEntity> b)
    {
        ...
        b.Property(x => x.EnumStatus).HasConversion<MyShortEnumsConverter>();
    }

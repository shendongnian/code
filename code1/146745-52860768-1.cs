    public override void Configure(EntityTypeBuilder<MyEfEntity> b)
    {
        ...
        b.Property(x => x.EnumStatus).HasConversion<EnumToStringConverter>();
    }

    public void Configure(EntityTypeBuilder<ContactCategory> modelBuilder)
    {
        modelBuilder.ToTable("CONTACT_CATEGORY", _schema);
    
        modelBuilder.HasKey(x => x.ContactCategoryId);
    
        modelBuilder.Property(x => x.ContactCategoryId)
            .HasColumnName(@"ContactCategoryID")
            //.HasColumnType("int") Weirdly this was upsetting SQLite
            .IsRequired()
            .ValueGeneratedOnAdd()
            ;

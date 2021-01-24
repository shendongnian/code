    // Table & Column Mappings
    this.ToTable("db.TBL_CONFIG");
    this.Property(t => t.Id).HasColumnName("PK_CONF");
    this.Property(t => t.Key).HasColumnName("KEY");
    this.Property(t => t.Value).HasColumnName("VALUE");
    this.Property(t => t.ValueType).HasColumnName("VALUETYPE");
    this.Property(t => t.Description).HasColumnName("DESCRIPTION"); 

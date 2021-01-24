    modelBuilder.Entity<TblLine>().Map(m =>
    {
        m.MapInheritedProperties();
        m.ToTable("tblLines");
    });
    modelBuilder.Entity<TblDevice>().Map(m =>
    {
        m.MapInheritedProperties();
        m.ToTable("tblDevices");
    });

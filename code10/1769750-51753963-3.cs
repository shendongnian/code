    modelBuilder.Entity<Project>()
      .Map(prj =>
      {
        prj.MapInheritedProperties();
        prj.ToTable("Projects");
      });
    modelBuilder.Entity<Program>()
      .Map(pgm =>
      {
        pgm.MapInheritedProperties();
        pgm.ToTable("Programs");
      });
    modelBuilder.Entity<Project>()
      .HasOptional(prj => prj.Program)
      .WithMany(pgm => pgm.Projects)
      .HasForeignKey(prj => prj.ProgramID);

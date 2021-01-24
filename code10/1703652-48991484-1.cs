    public overrid void OnModelCreating(...)
    {
        // The Tag.Text must be unique, we put it in an Index
        modelBuilder.Entity<Tag>()
            .Property(tag => tag.Text)
            .HasUniqueIndexAnnotation("IndexTagText", 0)
    }

    static void ConfigureBase<T>(EntityTypeBuilder<T> builder) where T : ImageBase
    {
       builder.Property(u => u.ImageDescription)
            .HasMaxLength(ConfigurationHelpers.MaxStringLengths.Descriptions)
            .IsRequired();
        builder.Property(u => u.ImageFileExtension)
            .HasMaxLength(ConfigurationHelpers.MaxStringLengths.ShortText)
            .IsRequired();
        builder.Property(u => u.ImageTitle)
            .HasMaxLength(ConfigurationHelpers.MaxStringLengths.FileNames)
            .IsRequired();
        builder.Property(u => u.ImageFileName)
            .HasMaxLength(ConfigurationHelpers.MaxStringLengths.FileNames)
            .IsRequired();
        builder.Property(u => u.ImageUrl)
            .HasMaxLength(ConfigurationHelpers.MaxStringLengths.Urls)
            .IsRequired();
    }

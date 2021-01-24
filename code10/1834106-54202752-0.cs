    var converter = new BoolToStringConverter("", "X");
    
    entity.Property(e => e.LockNote)
        .HasColumnName("LOCK_NOTE")
        .HasMaxLength(1)
        .IsUnicode(false)
        .HasConversion(converter);

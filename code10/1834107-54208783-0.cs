    var boolCharConverter =
        new ValueConverter<bool, string>(v => v ? "X" : "", v => v == "X");
    
    entity.Property(e => e.LockNote)
        .HasColumnName("LOCK_NOTE")
        .IsUnicode(false)
        .HasConversion(typeof(string))
        .HasConversion(boolCharConverter);

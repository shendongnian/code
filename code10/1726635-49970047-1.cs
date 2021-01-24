    modelBuilder.Entity<CourseMeeting>(cm =>
    {
        cm.HasKey(k => k.MID);
    
        cm.Property(p => p.MID)
            .UseSqlServerIdentityColumn();
    
        cm.HasMany(m => m.CourseMeetingParticipants)
            .WithRequired(m => m.CourseMeeting);
    });

    public class ProfileTypeConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(x => x.Id);
            builder.HasMany<Session>()
                .WithOne()
                .HasForeignKey(e => e.ProfileId)
                .HasConstraintName("FK_Profile_CurrentSession")
                .IsRequired();
            builder.HasOne(x => x.CurrentSession)
                .WithOne()
                .HasForeignKey<Profile>("CurrentSessionId")
                .HasConstraintName("FK_CurrentSession_Profile")
                .IsRequired(false);
        }
    }
    public class SessionTypeConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Session");
            builder.HasKey(x => x.Id);
        }
    }

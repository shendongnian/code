    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public virtual void Configure ( EntityTypeBuilder<Manager> builder )
        {
            builder.HasKey(e => e.ManagerId);
            builder.HasOne(d => d.ManagerUserLogin)
                .WithMany(p => p.Manager)
                .HasForeignKey(d => d.ManagerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Manager_User_ID");
        }
    }    

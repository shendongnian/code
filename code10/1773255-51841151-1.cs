    public class WfModelItemConfiguration : EntityTypeConfiguration<WfModelItem>
    {
        public WfModelItemConfiguration()
        {
            HasMany(n => n.Processes)
                .WithMany(p => p.Nodes);
        }
    }
    public class ProcessConfiguration : EntityTypeConfiguration<Process>
    {
        public ProcessConfiguration()
        {
            this.HasMany(oj => oj.Children)
                .WithOptional(j => j.Parent)
                .HasForeignKey(j => j.ParentId);
            this.HasMany(n => n.Nodes)
                .WithMany(p => p.Processes);
            this.HasOptional(p => p.Parent)
                .WithMany()
                .HasForeignKey(p => p.ParentId);
        }
    }

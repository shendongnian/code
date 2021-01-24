    public class Table2Configuration : EntityTypeConfiguration<Table2>
    {
        ...
        this.HasOptional(t => t.Table3)
            .WithRequired(o => o.Table2)
            .WillCascadeOnDelete(true);
        this.HasOptional(t => t.Table4)
            .WithRequired(o => o.Table2)
            .WillCascadeOnDelete(true);
    }

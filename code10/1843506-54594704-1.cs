    public class Table1
    {
        public int Id { get; set; }
        public virtual ICollection<Table2> Table2Objects { get; set; }
        public virtual Table2WithUniqueColumn456 Table2Object456 { get; set; }
    }
    [Table("Table2")]
    public class Table2
    {
        public int Id { get; set; }
        public int Table1Id { get; set; }
        public int UniqueColumnAtTable2ForGivenTable1Id { get; set; }
    }
    [Table("Table2")] // this will tell EF to use table-per-hierarchy
    public class Table2WithUniqueColumn456 : Table2
    {
    }
    public class Table1_Mapping : EntityTypeConfiguration<Table1>
    {
        public class Table1()
        {
            this.HasKey(x => x.Id);
            this.HasMany(x => x.Table2Objects).WithOptional().HasForeignKey(x => x.Table1);
            this.HasOne(x => x.Table2Object456).WithOptional().HasForeignKey(x => x.Table1);
        }
    }

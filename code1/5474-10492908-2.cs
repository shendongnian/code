    public partial class ContextAttributes : Context 
    {
        public ContextAttributes(string connectionString)
            : base(connectionString) {
        }
        [Table(Name="mytable")]
        [Column(Member="ID", IsPrimaryKey=true)]
        [Column(Member="Field1")]
        [Column(Member="Field2")]
        [Column(Member="Field3")]
        public override IEntityTable<MyTable> MyTables 
        {
            get { return base.MyTables; }
        }
    }

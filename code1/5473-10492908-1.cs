    public partial class Context : DbEntityContextBase 
    {
        public Context(string connectionString)
            : this(connectionString, typeof(ContextAttributes).FullName) 
        {
        }
        public Context(string connectionString, string mappingId)
            : this(VfpQueryProvider.Create(connectionString, mappingId)) 
        {
        }
        public Context(VfpQueryProvider provider)
            : base(provider) 
        {
        }
        public virtual IEntityTable<MyTable> MyTables 
        {
            get { return this.GetTable<MyTable>(); }
        }
    }

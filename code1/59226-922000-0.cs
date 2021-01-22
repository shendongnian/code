     [Database(Name = "Blah")]
    	public partial class TestDataContext : System.Data.Linq.DataContext
    	{
    		
    		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
    		
        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertAdmin(Admin instance);
        partial void UpdateAdmin(Admin instance);
        partial void DeleteAdmin(Admin instance);
        partial void InsertUser(User instance);
        partial void UpdateUser(User instance);
        partial void DeleteUser(User instance);
        #endregion
    		
    		public TestDataContext() : 
    				base(global::TestStuff.Properties.Settings.Default.FraudAnalystConnectionString, mappingSource)
    		{
    			OnCreated();
    		}
    		
    		public TestDataContext(string connection) : 
    				base(connection, mappingSource)
    		{
    			OnCreated();
    		}
    		
    		public TestDataContext(System.Data.IDbConnection connection) : 
    				base(connection, mappingSource)
    		{
    			OnCreated();
    		}
    		
    		public TestDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
    				base(connection, mappingSource)
    		{
    			OnCreated();
    		}
    		
    		public TestDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
    				base(connection, mappingSource)
    		{
    			OnCreated();
    		}

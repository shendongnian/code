    public class DataAccess
    {
        public DataAccess()
        {
        }
        public System.Collections.IEnumerable GetSchoolData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            Database db = DatabaseFactory.CreateDatabase(connectionString);
            string sqlCommand = "GetSchoolData";
            DbCommand comm = db.GetStoredProcCommand(sqlCommand);
            //db.AddInParameter(comm, "SchoolId", DbType.Int32); // this is in case you want to add parameters to your stored procedure
    
            return db.ExecuteDataSet(comm);
        }
    }

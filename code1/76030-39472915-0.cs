    public interface IDataReaderParser
    {
        void Parse(IDataReader reader);
    }
    public class Foo : IDataReaderParser
    {
    	public string Name { get; set; }
        public int Age { get; private set; }
    	
    	public void Parse(IDataReader reader)
    	{
    		Name = reader["Name"] as string;
            Age = Convert.ToInt32(reader["Age"]);
    	}
    }
    public class DataLoader
    {
        public static IEnumerable<TEntity> GetRecords<TEntity>(string connectionStringName, string storedProcedureName, IEnumerable<SqlParameter> parameters = null)
                    where TEntity : IDataReaderParser
        {
            using (var sqlCommand = new SqlCommand(storedProcedureName, Connections.GetSqlConnection(connectionStringName)))
            {
                using (sqlCommand.Connection)
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    AssignParameters(parameters, sqlCommand);
                    sqlCommand.Connection.Open();
    
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            //Create an instance and parse the reader to set the properties
                            var entity = Activator.CreateInstance<TEntity>();
                            entity.Parse(sqlDataReader);
                            yield return entity;
                        }
                    }
                }
            }
        }
    }

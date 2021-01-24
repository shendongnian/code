    public class RetrieveDataClass
    {
        private IDbConnection connection;
        public RetrieveDataClass(System.Data.IDbConnection connection)
        {
            // Setup class variables
            this.connection = connection;
        }
        /// <summary>
        /// <para>Retrieves the given record from the database</para>
        /// </summary>
        /// <param name="id">The identifier for the record to retrieve</param>
        /// <returns></returns>
        public EventDataModel GetDataEvent(int id)
        {
            EventDataModel data = new EventDataModel();
            string sql = "SELECT id,Telephone,CreatedSaved,Topic,Summary,Category,Body1,Body2,Body3,Body4 WHERE id = @id";
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                IDbDataParameter identity = cmd.CreateParameter();
                identity.ParameterName = "@id";
                identity.Value = id;
                identity.DbType = DbType.Int32; // TODO: Change to the matching type for id column
                cmd.Parameters.Add(identity);
                try
                {
                    connection.Open();
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.id = reader.GetInt32(reader.GetOrdinal("id"));
                            // TODO : assign the rest of the properties to the object
                        }
                        else
                        {
                            // TODO : if method should return null when data is not found
                            data = null;
                        }
                    }
                    // TODO : Catch db exceptions
                } finally
                {
                    // Ensure connection is always closed
                    if (connection.State != ConnectionState.Closed) connection.Close();
                }
            }
            // TODO : Decide if you should return null, or empty object if target cannot be found.
            return data;
        }
        // TODO : Insert, Update, Delete methods
    }

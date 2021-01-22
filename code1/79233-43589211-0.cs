    private static string ConnString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private SqlConnection Conn = new SqlConnection(ConnString);
        public void ExecuteStoredProcedure(string procedureName)
        {
            SqlConnection sqlConnObj = new SqlConnection(ConnString);
            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
        }
        public void ExecuteStoredProcedure(string procedureName, object model)
        {
            var parameters = GenerateSQLParameters(model);
            SqlConnection sqlConnObj = new SqlConnection(ConnString);
            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            foreach (var param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }
            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
        }
        private List<SqlParameter> GenerateSQLParameters(object model)
        {
            var paramList = new List<SqlParameter>();
            Type modelType = model.GetType();
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    paramList.Add(new SqlParameter(property.Name, DBNull.Value));
                }
                else
                {
                    paramList.Add(new SqlParameter(property.Name, property.GetValue(model)));
                }
            }
            return paramList;
        }

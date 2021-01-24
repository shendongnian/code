        static void Main(string[] args)
        {
            int routesInserted = 0;
            SqlConnection connString = new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=test;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("[RC_SP_ROUTE_REPOSITORY_DML]", connString)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.CommandTimeout = 5000;
            cmd.Parameters.Add("@RAWFILES_ID", SqlDbType.Xml);
            SqlParameter retValue = cmd.Parameters.Add("@RowCount", SqlDbType.Int);
            retValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters["@RAWFILES_ID"].Value = "<rawfile><id>1001</id><id>1002</id><id>1003</id></rawfile>";
            connString.Open();
            cmd.ExecuteNonQuery();
            int x = (int)(retValue.Value);
        }

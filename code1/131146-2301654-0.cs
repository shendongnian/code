        public const string sqlDataConnectionDetails = "Data Source=SQLSERVER\\SQLEXPRESS;Initial Cata....";
        public static string sqlGetDatabaseRows(string varDefinedConnection) {
            string varRows = "";
            const string preparedCommand = @"
                        SELECT SUM(row_count) AS 'Rows'
                        FROM sys.dm_db_partition_stats
                        WHERE index_id IN (0,1)
                        AND OBJECTPROPERTY([object_id], 'IsMsShipped') = 0;";
            using (var varConnection = Locale.sqlConnectOneTime(varDefinedConnection))
            using (var sqlQuery = new SqlCommand(preparedCommand, varConnection))
            using (var sqlQueryResult = sqlQuery.ExecuteReader())
                while (sqlQueryResult.Read()) {
                    varRows = sqlQueryResult["Rows"].ToString();
                }
            return varRows;
        }
        public static SqlConnection sqlConnectOneTime(string varSqlConnectionDetails) {
            SqlConnection sqlConnection = new SqlConnection(varSqlConnectionDetails);
            try {
                sqlConnection.Open();
            } catch (Exception e) {
                MessageBox.Show("Błąd połączenia z serwerem SQL." + Environment.NewLine + Environment.NewLine + "Błąd: " + Environment.NewLine + e, "Błąd połączenia");
            }
            if (sqlConnection.State == ConnectionState.Open) {
                return sqlConnection;
            }
            return null;
        }

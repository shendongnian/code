        /// <summary>
        /// Counts the number of rows in a given table.
        /// </summary>
        /// <param name="tableName">The name of the table to query.</param>
        /// <param name="closeConnectionWhenDone">A flag indicating whether the connection should be closed once the query is executed.</param>
        /// <returns>The number of rows in the table.</returns>
        private static int GetNumRowsInTable(string tableName, bool closeConnectionWhenDone = false)
        {
            string selectQueryString = String.Format("select 1 from {0};", tableName);
            int numRows = 0;
            CommandBehavior behavior = closeConnectionWhenDone ? CommandBehavior.CloseConnection : CommandBehavior.Default;
            using (var command = new OdbcCommand(selectQueryString, ODBCHelper.Connection))
            using (var reader = command.ExecuteReader(behavior))
            {
                while (reader.Read())
                {
                    numRows++;
                }
            }
            return numRows; 
        }

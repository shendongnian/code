        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <param name="parameters">Name/value dictionary of parameters</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql, Dictionary<string, object> parameters)
        {
            return Update(sql, CommandType.Text, parameters);
        }
        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <param name="commandType">CommandType.Text or CommandType.StoredProcedure</param>
        /// <param name="parameters">Name/value dictionary of parameters</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql, CommandType commandType, Dictionary<string, object> parameters)
        {
            return NonQuery(sql, parameters);
        }

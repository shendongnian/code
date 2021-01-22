        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql)
        {
            return NonQuery(sql, null);
        }
        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <param name="parameters">Name/value dictionary of parameters</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql, Dictionary<string, object> parameters)
        {
            return NonQuery(sql, parameters);
        }

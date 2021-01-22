        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql)
        {
            return NonQuery(sql, null);
        }
        public static int NonQuery(string sql, Dictionary<string, object> parameters)

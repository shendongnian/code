        public static int NonQuery(string sql, Dictionary<string, object> parameters)
        {
            return NonQuery(sql, CommandType.Text, parameters);
        }
        public static int NonQuery(string sql, CommandType commandType, Dictionary<string, object> parameters)

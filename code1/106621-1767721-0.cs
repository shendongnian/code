    public class SQLiteVariable
    {
        public SQLiteVariable() : this (null, string.Empty)
        {}
        public SQLiteVariable(SQLiteConnection connection) : this(connection, string.Empty)
        {}
        public SQLiteVariable(string name) : this(null, name)
        {}
        public SQLiteVariable(SQLiteConnection connection, string name)
        {
            Connection = connection;
            Name = name;
        }
        /// <summary>
        /// The table name used for storing the database variables
        /// </summary>
        private const string VariablesTable = "__GlobalDatabaseVariablesTable";
        /// <summary>
        /// Gets or sets the SQLite database connection.
        /// </summary>
        /// <value>The connection.</value>
        public SQLiteConnection Connection { get; set; }
        /// <summary>
        /// Gets or sets the SQLite variable name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the SQLite variable value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                CheckEnviornemnt();
                var cmd = new SQLiteCommand(Connection)
                              {
                                  CommandText = "SELECT Value FROM " + VariablesTable + " WHERE Key=@VarName"
                              };
                cmd.Parameters.Add(new SQLiteParameter("@VarName", Name));
                var returnValue = cmd.ExecuteScalar();
                return returnValue as string;
            }
            set
            {
                CheckEnviornemnt();
                // Assume the variable exists and do an update
                var cmd = new SQLiteCommand(Connection)
                {
                    CommandText = "INSERT OR REPLACE INTO " + VariablesTable + " (Key, Value) VALUES(@VarName, @Value)"
                };
                cmd.Parameters.Add(new SQLiteParameter("@Value", value));
                cmd.Parameters.Add(new SQLiteParameter("@VarName", Name));
                var count = cmd.ExecuteNonQuery();
            }
        }
        private void CheckEnviornemnt()
        {
            if (Connection == null) throw new ArgumentException("Connection was not initialized");
            var cmd = new SQLiteCommand(Connection)
            {
                CommandText = "CREATE TABLE IF NOT EXISTS "+VariablesTable+" (Key VARCHAR(30) PRIMARY KEY, Value VARCHAR(256));"
            };
            cmd.ExecuteNonQuery();
        }
    }

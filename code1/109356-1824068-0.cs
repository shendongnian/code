    class Database {
        private string connectionString;
        private readonly object syncRoot = new object();
        public Database(string connectionString) {
            this.connectionString = connectionString;
        }
		
        public void ExecuteReader(SqlCommand command, Action<IDataRecord> forEachRow) {
            lock (syncRoot) {
                using (var connection = new SqlConnection(connectionString)) {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            forEachRow(reader);
                        }
                    }
                }
            }
        }
    }
	
    var myDB = new Database("connection string");
    var myCommand = new SqlCommand("select id from blah");
	myDB.ExecuteReader(myCommand, row => Console.WriteLine("ID: {0}", row["id"]));

    using(MySqlConnection conn = new MySqlConnection(connStr)) {
        if (conn.State == ConnectionState.Closed)
            try {
                conn.Open();
            } catch (MySqlException ex) {
                // Exception handling here...
            }
        // Use of connection here...
    }

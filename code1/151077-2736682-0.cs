    using (SqlConnection conn = new SqlConnection("<CONNECTION_STRING>")) {
        conn.Open();
        using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", conn)) {
            comm.ExecuteNonQuery();
        }
        // Do your own stuff here but you must use the same connection object
        // The SET command applies to the connection. Any other connections will not
        // be affected, nor will any new connections opened. If you want this applied
        // to every connection, you must do it every time one is opened.
    }

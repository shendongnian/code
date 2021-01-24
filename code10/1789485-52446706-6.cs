        protected DataSet GetData()
        {
            // our select query to obtain all the rows from the contacts table
            string selectQuery = "SELECT * FROM contacts";
            // Where the data from the underlying table will be stored
            DataSet ds = new DataSet();
            // Connect to the database and get the data from the "contacts" table
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn))
                {
                    da.Fill(ds, "contacts"); // Add the rows from the "contacts" table to our dataset
                }
            }
            return ds;
        }

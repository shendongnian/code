        protected void UpdateTable(DataSet ds)
        {
            SqlConnection conn = new SqlConnection(connString);
            // Insert, update and delete queries
            string updateQuery = "UPDATE contacts SET fname=@first,mname=@middle,lname=@last WHERE ID=@id";
            string deleteQuery = "DELETE FROM contacts WHERE ID=@id";
            string insertQuery = "INSERT INTO contacts VALUES(@first,@middle,@last)";
            // Create the parameters for the queries above
            SqlParameter[] insertParams = new SqlParameter[]
            {
                // the first parameter (e.g. @first) has to match with the declaration in the query
                // the second parameter (e.g.SqlDbType.NVarChar) is the data type of the actual column in the source table
                // the third paramter (e.g. 100) is the length of the data in the database table's column
                // the last parameter (e.g. "fname") is the DataPropertyName of the source column which is
                // basically the name of the database table column that the DGV column represents
                new SqlParameter("@first", SqlDbType.NVarChar, 100, "fname"),
                new SqlParameter("@middle", SqlDbType.NVarChar, 100, "mname"),
                new SqlParameter("@last", SqlDbType.NVarChar, 100, "lname")
            };
            SqlParameter[] updateParams = new SqlParameter[]
            {
                new SqlParameter("@first", SqlDbType.NVarChar, 100, "fname"),
                new SqlParameter("@middle", SqlDbType.NVarChar, 100, "mname"),
                new SqlParameter("@last", SqlDbType.NVarChar, 100, "lname"),
                new SqlParameter("@id", SqlDbType.Int, 100, "id")
            };
            SqlParameter[] DeleteParams = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int, 100, "id")
            };
            // Create the SqlCommand objects that will be used by the DataAdapter to modify the source table
            SqlCommand insertComm = new SqlCommand(insertQuery, conn);
            SqlCommand updateComm = new SqlCommand(updateQuery, conn);
            SqlCommand deleteComm = new SqlCommand(deleteQuery, conn);
            // Associate the parameters with the proper SqlCommand object
            insertComm.Parameters.AddRange(insertParams);
            updateComm.Parameters.AddRange(updateParams);
            deleteComm.Parameters.AddRange(DeleteParams);
            // Give the DataAdapter the commands it needs to be able to properly update your database table
            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                InsertCommand = insertComm,
                UpdateCommand = updateComm,
                DeleteCommand = deleteComm
            };
            // A DataTable and a DataSet are basically the same. Except the DataSet is a collection of DataTables
            // Here, you can see that we've accessed a specific DataTable in the DataSet.
            // Calling the Update method executes the proper command based on the modifications to the specified
            // DataTable object then commits these changes to the database
            dataAdapter.Update(ds.Tables["contacts"]);
        }

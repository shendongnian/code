    /// <summary>
    /// A collection of methods for easy manipulation of the data in a given SQL table
    /// </summary>
    class DBOps
    {
        // The connection string contains parameters that dictate how we connect to the database
        private string connString = ConfigurationManager.ConnectionStrings["contactsConnectionString"].ConnectionString;
        // The table the instance of the class will be interacting with
        private string srcTable;
        // The SqlConnection Object that we will be using to connect to the database
        SqlConnection conn;
        // The DataAdapter object that we will be using to interact with our database
        SqlDataAdapter da;
        // The DataSet that we will be storing the data retrieved from the database
        DataSet ds;
        // The queries we would be using to manipulate and interact with the data in the database
        private string selectQuery;
        private string updateQuery;
        private string deleteQuery;
        private string insertQuery;
        // The collection of parameters for the queries above
        private SqlParameter[] insertParams;
        private SqlParameter[] updateParams;
        private SqlParameter[] DeleteParams;
        // The command objects that will be used by our data adapter when
        // interacting with the database
        private SqlCommand insertComm;
        private SqlCommand updateComm;
        private SqlCommand deleteComm;
        /// <summary>
        /// Initialize a new instance of the DBOps class
        /// </summary>
        /// <param name="tableName">The name of the table that the object will be interacting with</param>
        public DBOps(string tableName)
        {
            // Initialize the SqlConnection object
            conn = new SqlConnection(connString);
            // Initialize our collection of DataTables
            ds = new DataSet();
            srcTable = tableName;
            // initialize the query strings
            // What I do the strings below is an example of String Interpolation. Basically, this is a fancy way of
            // doing String.Format(). These strings are also called template strings
            selectQuery = $"SELECT * FROM {tableName}";
            insertQuery = $"INSERT INTO {tableName}(fname, mname, lnmae) VALUES(@first, @middle, @last";
            updateQuery = $"UPDATE {tableName} SET fname=@first, mname=@middle, lname=@last WHERE ID=@id";
            deleteQuery = $"DELETE FROM {tableName} WHERE ID=@id";
            // Initialize the collection of parameters for each query above
            insertParams = new SqlParameter[]
            {
                // new SqlParameter(@paramName, paramDataType, paramValueLength, DGVDataPropertyName);
                new SqlParameter("@first", SqlDbType.NVarChar, 100, "fname"),
                new SqlParameter("@middle", SqlDbType.NVarChar, 100, "mname"),
                new SqlParameter("@last", SqlDbType.NVarChar, 100, "lname")
            };
            updateParams = new SqlParameter[]
            {
                new SqlParameter("@first", SqlDbType.NVarChar, 100, "fname"),
                new SqlParameter("@middle", SqlDbType.NVarChar, 100, "mname"),
                new SqlParameter("@last", SqlDbType.NVarChar, 100, "lname"),
                new SqlParameter("@id", SqlDbType.Int, 100, "id")
            };
            DeleteParams = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int, 100, "id")
            };
            // Initialize the SqlCommand objects that will be used by the DataAdapter to modify the source table
            insertComm = new SqlCommand(insertQuery, conn);
            updateComm = new SqlCommand(updateQuery, conn);
            deleteComm = new SqlCommand(deleteQuery, conn);
            // Associate the parameters with the proper SqlCommand object
            insertComm.Parameters.AddRange(insertParams);
            updateComm.Parameters.AddRange(updateParams);
            deleteComm.Parameters.AddRange(DeleteParams);
            // Give the DataAdapter the commands it needs to be able to properly update your database table
            da = new SqlDataAdapter()
            {
                InsertCommand = insertComm,
                UpdateCommand = updateComm,
                DeleteCommand = deleteComm
            };
        }
        /// <summary>
        /// Retrieve the data from the SQl table
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            // Connect to the database and get the data from the "contacts" table
            using (conn)
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn))
                {
                    da.Fill(ds); // Add the rows from the "contacts" table to our dataset
                }
            }
            return ds;
        }
        /// <summary>
        /// Commit the changes present in the object's DataSet to the Database
        /// </summary>
        public void UpdateData()
        {
            // Calling the Update method executes the proper command based on the modifications to the specified
            // DataTable object
            da.Update(ds.Tables[srcTable]);
        }
    }

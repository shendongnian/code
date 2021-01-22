        /// <summary>
        /// Returns a count of the number of items in the database.
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfItemsInDB()
        {
            // Initialize the count variable to be returned
            int count = 0;            
            // Start connection to db
            using (SqliteConnection db =
                new SqliteConnection("Filename=" + _STR_DB_FILENAME))
            {
                // open connection
                db.Open();
                SqliteCommand queryCommand = new SqliteCommand();
                queryCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                queryCommand.CommandText = "SELECT COUNT(*) FROM " + _STR_TABLE_NAME;
                // Execute command and convert response to Int
                count = Convert.ToInt32(queryCommand.ExecuteScalar());
                // Close connection
                db.Close();
            }
            // return result(count)
            return count;
        }

        private const string dbConnection = "USE THE UDL STRING HERE";
        private void btnClick_Click(object sender, EventArgs e)
        {
            string first = txtFname.Text;
            string last = txtLname.Text;
            //I think the orig code was missing the single quotes
            string query = string.Format("INSERT INTO Practice ('{0}','{1}')", first, last);
            
            int rowsAffected = 0;
            //Using statement will automatically close the connection for you
            //Using a const for connection string ensures .NET Connection Pooling
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                //Creates a command associated with the SqlConnection
                SqlCommand cmd = conn.CreateCommand();
                
                //Set your sql statement
                cmd.CommandText = query;
                //open the connection
                cmd.Connection.Open();
                //Execute the connection
                rowsAffected = cmd.ExecuteNonQuery();
            }
            MessageBox.Show(rowsAffected + " rows Affected");
        }

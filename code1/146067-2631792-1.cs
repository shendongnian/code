    [WebMethod]
        public static void SaveData(string CustomerName, string CustomerPhoneNumber, string ColorID)
        {
            string Server = "al2c06";
            string Username = "app_AmbreenTesting";
            string Password = "testing";
            string Database = "AmbreenTesting";
    
            string ConnectionString = "Data Source=" + Server + ";";
            ConnectionString += "User ID=" + Username + ";";
            ConnectionString += "Password=" + Password + ";";
            ConnectionString += "Initial Catalog=" + Database;
            string query = "INSERT INTO Customer_Order(customerName, customerPhoneNumber, colorID)";
            query += "VALUES (";
            query += "'" + Request.Form["CustomerName"].ToString()+ "'";
            query += ",";
            query += "'" + Request.Form["CustomerPhoneNumber"].ToString() + "'";
            query += ",";
            query += "'" + Request.Form["ColorID"].ToString()+ "'";
            query += ")";
    
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            //lblSQL.Text = query;
            //pnlConfirm.Visible = true;
        }

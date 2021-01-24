                var connstr = db.Database.Connection.ConnectionString;
                SqlConnection connection;
                connection = new SqlConnection(connstr);
                connection.Open();
                SqlDataAdapter adapter = null;
                DataTable tab = new DataTable();
                adapter = new SqlDataAdapter("select Query from [Drag-Drop] where [User_ID] = '" + UserID + "' order by Clock desc", connection);
                adapter.Fill(tab);
                string DQuery = tab.Rows[0][0].ToString();

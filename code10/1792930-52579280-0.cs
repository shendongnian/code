    using (SqlConnection con = new SqlConnection(connection_string))
			{
				con.Open();
				// 2
				// Create new DataAdapter
				using (SqlDataAdapter a = new SqlDataAdapter(
					"SELECT * FROM Contacts", con))
				{
					// 3
					// Use DataAdapter to fill DataTable
					DataTable t = new DataTable();
					a.Fill(t);
					// 4
					// Render data onto the screen
					Data_table.DataSource = t;
				}
			}

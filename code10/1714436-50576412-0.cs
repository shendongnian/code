            if (conn.State == ConnectionState.Open)
            {
                // you should always use parameterized queries to avoid SQL Injection
                cmd.Parameters.Add("@FName", OleDbType.VarChar).Value = fstName;
                cmd.Parameters.Add("@LName", OleDbType.VarChar).Value = lstName;
                cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = adres;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(@"Data Added");
                    conn.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source + "\n" + ex.Message);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show(@"Connection Failed");
            }

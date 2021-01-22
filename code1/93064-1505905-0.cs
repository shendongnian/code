            private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = null;
            OleDbTransaction t = null;
            try
            {
                conn = new OleDbConnection("a database");
                conn.Open();
                //query both tables to prevent insert fail, 
                //obviously UserID should be parameter.
                var cmd = new OleDbCommand("select count(*) from User where UserID = 1", conn);
                var count = (double)cmd.ExecuteScalar();
                cmd.CommandText = "select count(*) from Email where UserID = 1";
                count += (double)cmd.ExecuteScalar();
                if (count != 0)
                {
                    MessageBox.Show("Record exists");
                    return;
                }
                t = conn.BeginTransaction();
                //insert logic goes here
                t.Commit();
            }
            catch (Exception x)
            {
                //we still need catch block, someone else may have updated the 
                //data after you checked but before you insert or db open may 
                //fail
                
                MessageBox.Show(x.Message);
                if (t != null)
                    t.Rollback();
            }
            finally
            {                
                if (conn != null)
                    conn.Close();
            }
        }

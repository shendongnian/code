    SqlConnection sqlConn;
        private bool dbConnectionExists() {
            try
            {
                sqlConn.ChangeDatabase("MyDBname");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dbConnectionExists())
            {
                // Connection ok so do something            
            }
        }

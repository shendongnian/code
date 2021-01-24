    private void VerificarPermissoes()
        {
            try
            {
                DataTable dt = new DataTable();
                string constring = String.Format("");
                string query = "SELECT id FROM users";
                
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    DbCommand command = con.CreateCommand();
                    command.CommandText = query;
                    dt.Load(command.ExecuteReader());
                }
                foreach (DataRow item in dt.Rows)
                {
                    Task.Factory.StartNew(delegate () { ProcessItem(item["id"].ToString()); });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ProcessItem(string item)
        {
            //do your stuff
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VerificarPermissoes();
        }
 

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
            AddControl(myControl, childControl);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VerificarPermissoes();
        }
 
        private void AddControl(Control ctrl, Control child)
            {
                if (ctrl.InvokeRequired)
                {
                    Action act = delegate () { AddControl(ctrl, child); };
                    this.Invoke(act);
                }
                else
                {
                    ctrl.Controls.Add(child);
                }
            }

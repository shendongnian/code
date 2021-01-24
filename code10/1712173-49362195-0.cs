    private void search_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter ada = new MySqlDataAdapter("select * from patient where firstname = '" + txtSearch.Text + "'" OR lastname = '" + txtSearch.Text + "'", con);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                label2.Text = dataGridView1.RowCount.ToString();
                result.Visible = true;
                result.Text ="Showing: "+ dataGridView1.RowCount.ToString()+ " results";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

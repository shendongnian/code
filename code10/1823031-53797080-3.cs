      private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pwd = textBox2.Text;
            MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; database = bot");
    
     string query = "Select * from license Where user = '" + textBox1.Text.Trim() + "' and pwd = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn );
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {    //change the name of the form depend on the form that you need to show.
                    frmMain objFrmMain = new frmMain();
                    this.Hide();
                    objFrmMain.Show();
                }
                else
                {
                    MessageBox.Show("Check your username and password");
                }
            
        }
 

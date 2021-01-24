    private void button2_Click(object sender, EventArgs e)
    {
        if (textBox1.Text != "")
        {
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                     con.Open();
                }
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DeathWish"].ToString();
                
                
                string query = string.Format("Select [ID],Decision from Data where [ID]='{0}' order by Decision", textBox1.Text);
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader dr = cmd.ExecuteReader();
                string[] s = new string[] { };
                while (dr.Read())
                {
                    s = dr["Decision"].ToString().Split(',');
                }
                int length = s.Length;
                for (int i = 0; i < length - 1; i++)
                {
                    string fetr = s[i];
                    for (int j = 0; j <= checkedListBox1.Items.Count - 1; j++)
                    {
                        if (checkedListBox1.Items[j].ToString() == s[i])
                        {
                            checkedListBox1.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
        }       

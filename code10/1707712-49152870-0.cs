    private void button2_Click(object sender, EventArgs e)
    {
        if (textBox1.Text != "")
        {
            // a SqlConnection enclosed in a `using` statement will auto-close, and will ensure other resources are correctly disposed
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DeathWish"].ToString())) 
            {
                try
                {
                    con.Open()
                    string[] s = new string[] { };                    
                    string query = "Select [ID],Decision from Data where [ID]=@id order by Decision";
                   
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlParameter idParam = new SqlParameter();
                    idParam.ParameterName = "@id";
                    idParam.Value = textBox1.Text;
                    cmd.Parameters.Add(idParam);
    
                    SqlDataReader dr = cmd.ExecuteReader();
                    
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
        }
    }   

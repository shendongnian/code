    private void button1_Click(object sender, EventArgs e)
            {
                
                SqlCommand cmd = null;
                SqlDataAdapter da = null;
                DataTable dt = null;
                Form form = null;
                int UserID = -1;
    
                try
                {
                    string Query = "select UserID from tblName where UserName = @Username ";
                    cmd = new SqlCommand(Query, con);
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    cmd.Parameters.AddWithValue("@Username", username.Text);
    
                    con.Open();
                    da.Fill(dt);
                    
                    if (dt.Rows.Count==0)
                    {
                        throw new Exception(string.Format("User '{0}' not founded", username.Text));
                    }
    
                    if (dt.Rows.Count>1)
                    {
                        throw new Exception(string.Format("User '{0}' founded but multiple", username.Text));
                    }
    
                    UserID = (int)dt.Rows[0]["UserID"];
    
                    switch (UserID)
                    {
                        case 1:
                            form = new adminPanel();
                            break;
    
                        case 2:
                            form = new teacherPanel();
                            break;
    
                        case 3:
                            form = new studentPanel();
                            break;
    
                        default:
                            throw new Exception(string.Format("User ID '{0}' not implemented", UserID));
                    }
    
                    this.Hide();
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    if (cmd != null) cmd.Dispose();
                    if (da != null) da.Dispose();
                    if (dt != null) dt.Dispose();
                }
            }

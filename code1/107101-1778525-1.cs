    void textbox_value_load()
            {
                SqlCommand cmdRe = new SqlCommand("select FK_RoleID from SO_User_Table", cn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                try
                {
                    cn.Open();
                    da.SelectCommand = cmdRe;
                    da.Fill(dt);
    
    
                    this.comboBox1.DataSource = da;
                    this.comboBox1.DataValueField = ""; //Name of the Id column
                    this.comboBox1.DataTextField = ""; //Name of the value/name column
                    this.comboBox1.DataBind();
    
    
                }
    
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
    
                    cn.Close();
                }
    
            }

     protected void Button1_Click(object sender, EventArgs e)
            {
                SqlConnection stormconn = new SqlConnection("Server=tcp:xxxx.database.windows.net,1433;Initial Catalog=xxxx;Persist Security Info=False;User ID=xxxxx;Password=xxxxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                {
                    SqlCommand insert = new SqlCommand("InsertFullname", stormconn);
                    insert.CommandType = CommandType.StoredProcedure;
                    insert.Parameters.AddWithValue("@Fullname", TextBox1.Text);
                   
    
                    stormconn.Open();
                    insert.ExecuteNonQuery();
                    stormconn.Close();
    
                    if (IsPostBack)
                    {
                        TextBox1.Text = ("");
                    }
                }
            }

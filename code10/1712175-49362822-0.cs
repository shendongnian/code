    private void btnReset_Click(object sender, EventArgs e){
    comboBox1.Items.Clear();
    CustomerInfo();
    }
    
    void CustomerInfo()
    {
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-39SPLT0;Initial Catalog=SalesandInventory;Integrated Security=True");
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select clName, cName from tblCustomer", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
    
                DataSet ds = new DataSet();
    
                sda.Fill(ds);
    
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
    
                    comboBox1.Items.Add(ds.Tables[0].Rows[i][0] + ", " + ds.Tables[0].Rows[i][1]);
    
                }
                con.Close();
    }

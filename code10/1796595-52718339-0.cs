    public void button1_Click(object sender, EventArgs e)
    {
        
            this.Size = new System.Drawing.Size(818, 608);
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select  CustomerCode, AccountNo, Branch, FirstName, LastName, Sex, MaritialStatus, MobileNo, Email, HomeCity from MasterTable where CustomerCode LIKE '%' + @CusCode AND FirstName LIKE '%' +@FirstName AND AccountNo LIKE '%' +@AccountNo AND Branch LIKE '%' +@Branch", connection);
            dataGridView1.Refresh();
            cmd.Parameters.AddWithValue("@CusCode", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@FirstName", txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", txtac.Text.Trim());
            cmd.Parameters.AddWithValue("@Branch", txtbranch.Text.Trim());
            cmd.ExecuteNonQuery();
            DataTable dtt = new DataTable();
            SqlDataAdapter sdap = new SqlDataAdapter(cmd);
            sdap.Fill(dtt);
            dataGridView1.DataSource = dtt;
           // sdap.Fill(dtt);    // Making the Rows Double
           // dataGridView1.DataSource = dtt;          
            connection.Close();
       
    }

    SqlDataAdapter adp = new SqlDataAdapter();
    DataSet ds = new DataSet();
    adp.SelectCommand = new SqlCommand("Your SQL Statement Here", con);
    adp.Fill(ds);
    con.Close();
    if (ds.Tables[0].Rows.Count  > 0)
    {
        settext = textBox1.Text;
        Admin_Main_Page AdminMainForm = new Admin_Main_Page();
        AdminMainForm.Show();
        this.Hide();
    }
    else{
       label4.Text = "Invalid Login Details";
    }

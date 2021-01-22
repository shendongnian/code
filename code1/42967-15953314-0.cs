    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    string query = "select Emp_ID,Emp_Name,Father_Name,Email from Employee where Emp_Name like '" + textBox1.Text + "%' ORDER BY Emp_Name ASC";
    using (SqlCommand comand = new SqlCommand(query, con))
    {
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = comand;
    DataTable ds = new DataTable();
    ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
    da.Fill(ds);
    dataGridView1.DataSource = ds;
    }
    } 

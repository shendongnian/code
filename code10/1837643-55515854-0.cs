    private void Ring_Load(object sender, EventArgs e)
    {
        showdata();
        showmedal();  
    }
    void showdata()
    {
        SqlConnection con = new SqlConnection(conn);
        SqlCommand cmd = new SqlCommand("SELECT Number,Weight,Ring_Id FROM Ring", con);
        da.SelectCommand = cmd;
        DataTable dt1 = new DataTable();
        da.Fill(dt1);
        dataGridView1.DataSource = dt1;
        dataGridView1.Columns[3].Visible = false;
    }
    void showmedal()
    {
        SqlConnection con = new SqlConnection(conn);
        SqlCommand cmd = new SqlCommand("SELECT Number,Weight,Ring_Id FROM medal", con);
        da.SelectCommand = cmd;
        DataTable dt2 = new DataTable();
        da.Fill(dt2);
        dataGridView2.DataSource = dt2;
    }

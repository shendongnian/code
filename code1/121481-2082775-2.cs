    protected void Page_Load(object sender, EventArgs e)
    {
    
        DataView dv= (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView dr in dv)
        {
        	Label1.Text = dr["Cost"].ToString();
        }
    }

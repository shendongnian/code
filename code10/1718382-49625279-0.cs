    public void BindGridviewActivity()
    {
        /*************Connectionstring is located in Web.config ******************/
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT T1.[ActivityID] FROM [BI_Planning].[dbo].[tlbActivity]", con);
            con.Open();
    
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
    
            if (ds.Tables.Count > 0)
            {
                gwActivity.DataSource = ds.Tables(0);
                gwActivity.DataBind();
            }
        }
    }

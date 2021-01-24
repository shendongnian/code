    protected void BtnSearch_Click1(object sender, EventArgs e)
    {
        string mainconn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        SqlConnection sqlconn = new SqlConnection(mainconn);
        sqlconn.Open();
        SqlCommand sqlcomm = new SqlCommand();
        string sqlquery = "SELECT * FROM [dbo].Imported_USPFOWEB_Pers_Unit_tbl WHERE (([upc] LIKE '%'+@upc+'%') OR  ([uname] LIKE '%'+@uname+'%') OR ([st_addr] LIKE '%'+@st_addr+'%') OR ([pr_nbr] LIKE '%'+@pr_nbr+'%'))";
        sqlcomm.CommandText = sqlquery;
        sqlcomm.Connection = sqlconn;
        // =========================================
        // here, you need to set the values of **ALL** parameters in your query!
        // @upc, @uname, @st_addr, @pr_nbr 
        // =========================================
        // sqlcomm.Parameters.AddWithValue("upc", TxtSearch.Text);
        sqlcomm.Parameters.Add("@upc", SqlDbType.VarChar, 50).Value = TxtSearch.Text;
        sqlcomm.Parameters.Add("@uname", SqlDbType.VarChar, 50).Value = ".....";
        sqlcomm.Parameters.Add("@st_addr", SqlDbType.VarChar, 50).Value =  ".....";
        sqlcomm.Parameters.Add("@pr_nbr", SqlDbType.VarChar, 50).Value =  ".....";
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

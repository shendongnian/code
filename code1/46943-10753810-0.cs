         if (!IsPostBack)
            {
                BindData();
            }
        }
    private void BindData()
    {
        SqlConnection cn = new SqlConnection("uid=test;pwd=te$t;server=10.10.0.10;database=TestDB");
        string strSQL = "Select * from table6";
        SqlDataAdapter dt = new SqlDataAdapter(strSQL, cn);
        DataSet ds = new DataSet();
        dt.Fill(ds);
        grd1.DataSource = ds;
        grd1.DataBind();
        cn.Close();
    }

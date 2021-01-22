    protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            SqlConnection con = new SqlConnection("Data Source=JEL-PC\\SQLSERVER2008;Initial Catalog=Jel;user id=sa;password=jel_2004;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from employee", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ViewState["ds"] = ds;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
    
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "ename";
    
            DropDownList1.DataValueField = "eid";
            DropDownList1.DataBind();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = DropDownList1.SelectedValue;
            int index=0;
            DataSet ds=new DataSet();
    
            ds=(DataSet)ViewState["ds"];
    
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                if(ds.Tables[0].Rows[i][0].ToString()==x)
                {
                    index=i;
                    Response.Write(ds.Tables[0].Rows[i][0].ToString()+" i="+i);
                }
            }
    
            GridView1.SelectedIndex = index;
            
    
        }

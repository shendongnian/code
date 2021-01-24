    protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
          {
            con.Open();
            string FetchData = "Select * from Physicians";
            cmd = new SqlCommand(FetchData, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ids = new string[dt.Rows.Count];
            names = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids[i] = dt.Rows[i][0].ToString();
                names[i] = dt.Rows[i][1].ToString();
            }
            DropDownList2.DataSource = names;
            DropDownList2.DataBind();
            con.Close();
         }
    }

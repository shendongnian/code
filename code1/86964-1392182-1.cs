     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Data();
            }
        }
        void Data()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            for (int i = 1; i <= 13; i++)
            {
                dt.Rows.Add(i.ToString());
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
       
        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            if (GridView1.PageCount == GridView1.PageIndex)
                Timer1.Enabled = false;
            GridView1.PageIndex++;
            Data();
        }

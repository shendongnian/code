      protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<int> s = Enumerable.Range(1, 10).ToList();
                DropDownList1.DataSource = s;
                DropDownList1.DataBind();
    
                DropDownList1.Items.Add("Other");
            }
        }

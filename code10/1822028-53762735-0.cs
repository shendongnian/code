    protected void Page_Load(object sender, EventArgs e)
    {
        //bind data not here
        if (IsPostBack == false)
        {
            //but inside the ispostback check
            ddlProduct.Items.Add(new ListItem("Item 1", "1"));
            ddlProduct.Items.Add(new ListItem("Item 2", "2"));
            ddlProduct.Items.Add(new ListItem("Item 3", "3"));
            ddlProduct.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = ddlProduct.SelectedValue;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<test1> lst = new List<test1>();
            lst.Add(new test1() { Id = 1, description = "R1", IsChecked = false });
            lst.Add(new test1() { Id = 3, description = "R2", IsChecked = true });
            lst.Add(new test1() { Id = 2, description = "R3", IsChecked = false });
            lst.Add(new test1() { Id = 4, description = "R4", IsChecked = false });
    
            repeater1.DataSource = lst;
            repeater1.DataBind();
        }
     }
    
    protected void rb1_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in repeater1.Items)
        {
            (item.FindControl("rb1") as RadioButton).Checked = false;
        }
        (sender as RadioButton).Checked = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var ds = new[]
        {
            new { FirstName = "F1", LastName = "L1" },
            new { FirstName = "F2", LastName = "L2" },
        };
    
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }

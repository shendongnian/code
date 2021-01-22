    private DataTable myTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        //populate dataTable
        if (!IsPostBack)
        {
            //databind to repeater
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in repeater1.Items)
        {
            DataRow row = myTable.Rows[item.ItemIndex];
        }
    }

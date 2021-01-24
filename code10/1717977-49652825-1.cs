    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        // adding dummy data into DataTable
        if (dt.Rows.Count == 0)
        {
            dt.Columns.Add("Column1");
            dt.Rows.Add("Row1");
            dt.Rows.Add("Row2");
        }
        if (!IsPostBack)
        {
            // setting and binding DataTable to GridView
            gvCostBreakdown.DataSource = dt;
            gvCostBreakdown.DataBind();
        }
    }
    protected void gvCostBreakdown_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Getting GridView row which clicked
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        // Check if LinkButton (AddRow) is clicked
        if (e.CommandName=="AddRow")
        {
            // getting the value of label inside GridView
            string rowCellValue = ((Label)row.FindControl("Label1")).Text;
            // setting value to TextBox which is inside First UpdatePanel
            txtTotal.Text = rowCellValue;
        }
    }

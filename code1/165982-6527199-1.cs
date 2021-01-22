    protected void Page_Load(object sender, System.EventArgs e)
    {
    	if (!IsPostBack) {
    		BindGrid();
    	}
    }
    
    private void BindGrid()
    {
    	DataTable source = new DataTable();
    	source.Columns.Add(new DataColumn("Value", typeof(string)));
    	DataRow row = source.NewRow();
    	row["Value"] = "A";
    	source.Rows.Add(row);
    	row = source.NewRow();
    	row["Value"] = "B";
    	source.Rows.Add(row);
    	row = source.NewRow();
    	row["Value"] = "C";
    	source.Rows.Add(row);
    	this.GridView1.DataSource = source;
    	this.GridView1.DataBind();
    }
    
    protected void TextChanged(object sender, EventArgs e)
    {
    	var chk = ((TextBox)sender).NamingContainer.FindControl("CheckMark");
    	chk.Visible = true;
    }
    
    protected void GridSelecting(object sender, GridViewSelectEventArgs e)
    {
    	this.GridView1.SelectedIndex = e.NewSelectedIndex;
    }

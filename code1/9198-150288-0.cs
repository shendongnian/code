    protected void Page_Load(object sender, EventArgs e)
    {
      DataGrid dg = new DataGrid();
      dg.GridLines = GridLines.Both;
      ButtonColumn bc = new ButtonColumn();
      bc.CommandName = "add";
      bc.HeaderText = "Event Details";
      bc.Text = "Details";
      bc.ButtonType = ButtonColumnType.PushButton;
      dg.Columns.Add(bc);
      dg.DataSource = getDataTable();
      dg.DataBind();
      dg.ItemCommand += new DataGridCommandEventHandler(dg_ItemCommand);
      pnlMain.Controls.Add(dg);
    }
    protected void dg_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.CommandName == "add")
      {
        throw new Exception("add it!");
      }
    }
    protected DataTable getDataTable()
    {
      // returns your data table
    }

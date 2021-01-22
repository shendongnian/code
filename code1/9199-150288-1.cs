    protected void Page_Load(object sender, EventArgs e)
    {
      DataGrid dg = new DataGrid();
    
      dg.GridLines = GridLines.Both;
    
      dg.Columns.Add(new ButtonColumn {
        CommandName = "add",
        HeaderText = "Event Details",
        Text = "Details",
        ButtonType = ButtonColumnType.PushButton
      });
    
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

    // Create DataGridView
    DataGridView gridView = new DataGridView();
    gridView.AutoGenerateColumns = false;
    gridView.Columns.Add("Col", "Col");
    
    // Create ContextMenu and set event
    ContextMenuStrip cMenu = new ContextMenuStrip();
    ToolStripItem mItem = cMenu.Items.Add("Delete");
    mItem.Click += (o, e) => { /* Do Something */ };           
    
    // This makes all rows added to the datagridview use the same context menu
    DataGridViewRow defaultRow = new DataGridViewRow();
    defaultRow.ContextMenuStrip = cMenu;

    private void FormatGrid()
    {
    	DataView dv = new DataView();
    	dv.Table = _loginDs.Tables[0];
    
    	DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
    	DatagridViewCheckBoxHeaderCell chkHeader = new DatagridViewCheckBoxHeaderCell();
    	chkbox.HeaderCell = chkHeader;
    	chkHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(chkHeader_OnCheckBoxClicked);
    	_chkBoxGrid.Columns.Add(chkbox);
    
    	DataGridViewTextBoxColumn uname = new DataGridViewTextBoxColumn();
    	uname.HeaderText = "user";
    	uname.Name = "username";
    	uname.DataPropertyName = "username";
    	_chkBoxGrid.Columns.Add(uname);
    
    	_chkBoxGrid.DataSource = dv;
    }
    
    void chkHeader_OnCheckBoxClicked(bool state)
    {
    	foreach (DataGridViewRow row in _chkBoxGrid.Rows)
    	    row.Cells[0].Value = state;
           
    }

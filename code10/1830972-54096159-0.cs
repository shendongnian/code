    void InsertTableLayoutPanelRow(int index)
    {
    	RowStyle newRowStyle = new RowStyle();
    	newRowStyle.Height = 50;
    	newRowStyle.SizeType = SizeType.Absolute;
    
    	tableLayoutPanel1.RowStyles.Insert(index, newRowStyle);
    	tableLayoutPanel1.RowCount++;
    	foreach (Control control in tableLayoutPanel1.Controls)
    	{
    		if (tableLayoutPanel1.GetRow(control) >= index)
    		{
    			tableLayoutPanel1.SetRow(control, tableLayoutPanel1.GetRow(control) + 1);
    		}
    	}
    
    }

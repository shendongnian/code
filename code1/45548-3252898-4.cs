    private void dtgworkingdays_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
    	this.FillRecordNo();
    }
        
        
    private void FillRecordNo()
    {
    	for (int i = 0; i < this.dtworkingdays.Rows.Count; i++)
    	{
    		this.dtgworkingdays.Rows[i].HeaderCell.Value = (i + 1).ToString();
    	}
    }

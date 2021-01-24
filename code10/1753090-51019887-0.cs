    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
	    if (dataGridView1.SelectedCells.Count > 0)
	    {
		    int index = dataGridView1.SelectedCells[0].RowIndex;
		    DataGridViewRow selectedRow = dataGridView1.Rows[index];
		
		    SrNo = selectedRow.Cells["SrNo"].Value.ToString();
            TypeNo = selectedRowCells["TypeNo"].Value.ToString();
            TestEng = selectedRowCells["TestEngineer"].Value.ToString();
            date = selectedRowCells["Date"].Value.ToString();
	    }
    }

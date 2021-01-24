    private void Supplierview_SelectionChanged(object sender, EventArgs e)
    {
    	var row = Supplierview.CurrentRow;
    	SupplierID.Text = row.Cells[0].Value.ToString();
    	CompanyName.Text = row.Cells[1].Value.ToString();
    	ContactName.Text = row.Cells[2].Value.ToString();
    	ContactNumber.Text = row.Cells[3].Value.ToString();
    	Date.Text = row.Cells[4].Value.ToString();
    	Address.Text = row.Cells[5].Value.ToString();
    	Remarks.Text = row.Cells[6].Value.ToString();
    }

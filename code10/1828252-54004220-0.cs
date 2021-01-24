    protected void dgvEmployeesInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName.Equals("Edit"))
    	{
    		int SelectedIndex;
    		if (int.TryParse(e.CommandArgument.ToString(), out SelectedIndex))
    		{
    			// make it selected after the click
    			dgvEmployeesInformation.SelectedIndex = SelectedIndex;
    			
    			// now use it...
    		}
    	}
    }

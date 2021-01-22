    private SomeType ccc;
    
    public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	this.ccc = lblTicketsA;
    }
    
    public void btnSubmit_Click(object sender, EventArgs e)
    {
    	try
    	{
    		this.ccc.text = "test"
    	}
    	catch (Exception ex)
    	{
    		lblDisplay.Text = ex.Message;
    	}
    }

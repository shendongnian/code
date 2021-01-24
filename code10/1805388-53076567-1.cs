    protected void Button1_Click(object sender, EventArgs e)
    {
    	if(ddldate.SelectedValue != null)
    	{
    		string deliverytime = ddldate.SelectedValue.ToString();
    		lbltest.Text = deliverytime;
    	}
    }

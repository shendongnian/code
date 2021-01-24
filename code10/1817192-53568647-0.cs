    private void combobox_SelectedIndexChanged(object sender, EventArgs e)
    {
    	if (comboBox1.SelectedIndex == 0)
    	{
    		Datagrid2.Visible = false;
    		Datagrid1.Visible = true;
    	}
    	else
    	{	Datagrid1.Visible = false;
    		Datagrid2.Visible = true;
    	}
    }

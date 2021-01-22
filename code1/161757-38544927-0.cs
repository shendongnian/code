    private void BindData()
    {
    	// can't bind the datetimepicker, so handle it manually...
    	if (o.myDate == null)
    	{
    		dtDatePicker.Checked = false;
    	}
    	else
    	{
    		dtDatePicker.Checked = true;
    		dtDatePicker.Value = o.myDate.Value;
    	}
    }
    private void Save()
    {
    	if (dtDatePicker.Checked)
    	{
    		o.myDate = dtDatePicker.Value;
    	}
    	else
    	{
    		o.myDate = null;
    	}
    }

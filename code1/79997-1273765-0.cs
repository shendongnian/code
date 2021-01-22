    if (c.SomeValue == null)
    {
        btnRecordCall.Enabled = false;
        btnAddAction.Enabled = false;
        btnProcesss.Enabled = false;
    }
    else
    {
        if(c.SomeProperty.Status != 'Y')
        {
            btnRecordCall.Enabled = false;
        }
	
        if((c.SomeProperty.Status != 'Y') &&
           (c.SomeOtherPropertyAction != 'Y'))
        {
            btnAddAction.Enabled = false;
        }
	
        if(c.SomeProperty.Processing != 'Y')
        {
            btnProcesss.Enabled = false;
        }
    }

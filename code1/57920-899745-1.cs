    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
    {
        if (chkSelect == null) 
        { 
            throw new ApplicationException("Dev is using the incorrect constructor"); 
        }
        this.FName= sFieldName;
        this.SelectCheckBox = chkSelect;
    }

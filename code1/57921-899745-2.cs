    // This is now the ONLY constructor you need
    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
    {
        OverrideSelect = (chkSelect == null);
        this.FName= sFieldName;
        this.SelectCheckBox = chkSelect;
    }
    
    // You could solve it differently by replacing OverrideSelect with this property:
    public readonly bool isChkSelectNull {
        get {
            return (this.chkSelect == null);
        }
    }
    
    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
    {
        this.FName= sFieldName;
        this.SelectCheckBox = chkSelect;
    }

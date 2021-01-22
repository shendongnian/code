    //Want to throw an ApplicationExceptioh if developer uses this constructor and passes
    //chkSelect = null
    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
      : this(sFieldName, chkSelect, chkSelect==null)
    {
      if(chkSelect==null) thow new ArgumentNullException("chkSelect");
    }
    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect, bool overrideSelect)    
    {
      this.FName= sFieldName;
      this.SelectCheckBox = chkSelect;
      OverrideSelect = overrideSelect;
    }

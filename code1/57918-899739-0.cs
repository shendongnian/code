    //Want to throw an ApplicationExceptioh if developer uses this constructor and passes
    //chkSelect = null
    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
    {
      if (chkSelect == null)
      {
        throw new ArgumentException("chkSelect cannot be null when using this constructor");
      }
      this.FName= sFieldName;
      this.SelectCheckBox = chkSelect;
    }

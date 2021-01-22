    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
      : this(sFieldName, chkSelect, null)
    {
    }
    public UIControl(string sFieldName, HtmlInputCheckBox chkSelect, bool overrideSelect)
      : this(sFieldName, chkSelect, overrideSelect)
    {
    }
    UIControl(string sFieldName, HtmlInputCheckBox chkSelect, bool? overrideSelect)
    {
      if (!overrideSelect.HasValue && chkSelect == null)
      {
          throw new ArgumentException("chkSelect");
      }
      FName = sFieldName;
      SelectCheckBox = chkSelect;
      OverrideSelect = overrideSelect ?? false;
    }

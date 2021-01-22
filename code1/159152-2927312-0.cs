    string _errorMessage;
    public override bool ApplyChanges()
    {
     try
     {
        // save properties
        return true;
     }
     catch(Exception ex)
     {
        _errorMessage = ex.Message; // is there any similar property I can fill?
        return false;
     }
    }
  
    protected override OnPreRender(EventArgs e)
    {
      if (!string.IsNullOrEmpty(_errorText))
      {
        this.Zone.ErrorText = string.Format("{0}<br />{1}", this.Zone.ErrorText,
                               _errorText);
      }      
      base.OnPreRender(e);
    }

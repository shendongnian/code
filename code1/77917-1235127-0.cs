    public void SetHidden(string s)
    {
      HtmlInputHidden myHidden = (HtmlInputHidden)this.Page.FindControl("txtHidden");
      myHidden.Value = s;
    }

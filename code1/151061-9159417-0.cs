    pageload()
    {
          AjaxPro.Utility.RegisterTypeForAjax(typeof(pagename), this.Page);
    }
  
    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public void methodname()
        {
        ..........
        ........
        }

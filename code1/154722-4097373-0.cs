    public string WebServiceResult
    {
      get
      {
        string text = (string) ViewState["WebServiceResult"];
        if (text != null)
           return text;
        else
           return string.Empty;
      }
      set
      {
        ViewState["WebServiceResult"] = value;
      }
    }

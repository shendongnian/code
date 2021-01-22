    private static string ResourceText;
    
    static [constructor]
    {
        ResourceText = //get resource;
    }
    
    private string text;
    public string Text;
    get
    {
       string tmp = (string)ViewState["Text"];
       if (!String.IsNullOrEmpty(tmp))
          text = tmp;
       else
          text = ResourceText;
       return text;
    }
    set
    {
       ViewState.Add("Text", value);
       // Note: passing null or empty strings will not work.
    }

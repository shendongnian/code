    // setting this as protected makes it available in markup
    protected string TaskName
    {
        get { return (string)Request.QueryString["VarName"] ?? String.Empty; }
    }

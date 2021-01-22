    public object GetObject
            {
                get
                {
                    if (ViewState["MyObject"] != null)
                    {
                        return ViewState["MyObject"];
                    }
    
                    return null;
                }
                set
                {
                    ViewState["MyObject"] = value;
                }
            }

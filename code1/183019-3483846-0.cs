    public List<string> StringList
    {
         get
            {
               if (Session["StringList"] == null)
                       Session["StringList"] = new List<string>();
    
                return Session["StringList"] as List<string>;
             }
    }

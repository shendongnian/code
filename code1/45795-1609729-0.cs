    public ListDictionary Items        
    {            
        get 
        {
            object o = ViewState["Items"];
            if (o == null)
            {
                ViewState["Items"] = new ListDictionary;
                o = ViewState["Items"];
            }
            return (ListDictionary) o;
        }
     }

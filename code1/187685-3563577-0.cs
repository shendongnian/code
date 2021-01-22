    [NonSerialized]
    private string _actionName; 
    public string ActionName 
        { 
            get 
            { 
                if (_actionName == null) 
                    _actionName = Request.Params["action_name"] != null 
                                      ? Server.UrlDecode(Request.Params["action_name"]) 
                                      : ""; 
     
                return _actionName; 
            } 
            set
            {
                _actionName= value;
             }
        }

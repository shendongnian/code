    public string UserName {
        get { 
            if( userName == null) {
                return string.Empty;
            }
            else {        
                return userName;                     
            }
        } 
        set { userName = value; }
    }
    

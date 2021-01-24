    public string nameuser
    {
        get { 
             return username;
            } 
       
        set { 
             if(username == value)
             {
                 return;
             }
             username= value; 
             OnPropertyChanged(nameof(nameuser));
            }
    }

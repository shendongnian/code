    private string _Text;
    public string Text
    {
       get
       {
         if(string.IsNullOrEmpty(_Text))
            //return the one from the resource file  
         else
            return _Text;
       }
    
       set
       {
          _Text = value;
       }
    }

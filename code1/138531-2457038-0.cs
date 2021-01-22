    private string name;
    
    public string Name 
    {
        get { return this.name; }
        set 
        {
           if (!string.IsNullOrEmpty(value))
           { 
               this.name = value;
           }
        }
    }

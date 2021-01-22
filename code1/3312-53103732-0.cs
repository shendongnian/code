    private string name;
    public string Name 
    {
        get 
        {
            if(name == null)
            {
                name = "Default Name";
            }
            return name;
        }
        set
        {
            name = value;
        }
    }

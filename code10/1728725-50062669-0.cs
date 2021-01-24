    public Form2()
    {
        InitializeComponent();
    }
    
    
    public Form2(string id, string name /* other arguments */) : this()
    {
       SetUser(id, name);
    }
    
    
    public void SetUser(string id, string name /* other arguments */)
    {
        this.Text = $"user logged: {name} ({id})";
        //do stuff
    }

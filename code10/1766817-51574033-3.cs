    private string _firstname;         
    public string Firstname
    {
         get { return _firstname; }
         set
         {
             _firstname = value;
             NotifyOfPropertyChange("Firstname");
             NotifyOfPropertyChange("Username");
         }
    }
    private string _lastname;         
    public string Lastname
    {
         get { return _lastname; }
         set
         {
             _lastname = value;
             NotifyOfPropertyChange("Lastname");
             NotifyOfPropertyChange("Username");
         }
    }

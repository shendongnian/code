    private string _firstname;         
    public string Firstname
    {
         get { return _firstName; }
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
         get { return __lastName; }
         set
         {
             _username = value;
             NotifyOfPropertyChange("Lastname");
             NotifyOfPropertyChange("Username");
         }
    }

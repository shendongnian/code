    private string firstName;
    private string lastName;  
  
    public string Name { get; set; }
    [NotMapped]
    public string FirstName { 
       get { return String.IsNullOrEmpty(Name) ? firstName : Name.Substring(0, Name.IndexOf(" ")); }
       set { firstName = value; }
    }
    [NotMapped]
    public string LastName { 
       get { return String.IsNullOrEmpty(Name) ? lastName : Name.Substring(Name.IndexOf(" ") + 1 : );} 
       set { lastName = value; }
    }

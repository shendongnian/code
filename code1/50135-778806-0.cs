    private string _email;
    protected string Email
    { 
       get { return _email; }
       set 
       {
           if(value.IndexOf("@") > 0)
               _email = value;
           else
                throw new ArgumentException("Not a valid Email");
       }
    }

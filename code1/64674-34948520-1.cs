    public string PopulateString(string emailBody)  
    {  
      User person = _db.GetCurrentUser();  
      string firstName = person.FirstName;    //  Peter  
      string lastName = person.LastName;      //  Pan  
      return StringExtension.Format(emailBody.Format(  
        firstname => firstName,  
        lastname => lastName  
      ));   
    } 

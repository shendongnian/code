    [HttpPost]
    public string CheckUser(UserCred model) 
    {
      if(!ModelState.IsValid)
      {
        return "0";
      }
        string uname = model.Uname;
        string pword = model.Pass;
        
        /* Your Code
         *  
         */
     }

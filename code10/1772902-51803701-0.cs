    using System.Linq;
    
    // assumes username and password contain the relevant user input
    
    // uses Linq's Any clause to test if Any entry in the list matches
    if (Login.Any(l => l.UserName == username && l.Password == password))
    {
      // login matched, go to next page
    }
    else 
    {
      // login did not match
    }

    class Employee
    {
       // ...
       private string code;
       public string Code
       {
          set
          {
             Regex regex = new Regex("^[A-Z]{1}[1-9]{1}[0,1]{1}[0-9]{3}[1-9]{1}$");
             Match match = regex.Match(value);
             if (!match.Success)
    	     {
    	        throw new ArgumentException("Employee must be in ... format");
    	     }            
             code = value;
           }
        }
       // ...
    }

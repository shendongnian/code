    private bool IsNumber(string text)
    {
       int number;
    
       //Allowing only numbers
       if (!(int.TryParse(text, out number)))
       {
          return false;
       }
       return true
    }

    public int doSomeWork(string value)
    {
       int result = 0; //default?
    
       if(string.IsNullOrEmpty(value))
       {
          result = 0;
       }
       else
       {
          result = int.Parse(value); //you could also consider using TryParse(...) if your string could possibly also be different from a number.
       }
    
       //do some calculations upon "result"
    
    
       return result;
    }
